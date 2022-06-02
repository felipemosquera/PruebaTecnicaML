using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Felipe_ML.Domain;
using Felipe_ML.Models;
using Microsoft.Extensions.Logging;

namespace Felipe_ML.Services
{
    public class MutantService : IMutant
    {
        private readonly ILogger<MutantService> _logger;
        public IDataPersistence _dataPersistenceService { get; }

        public MutantService(ILogger<MutantService> logger, IDataPersistence dataPersistenceService)
        {
            _dataPersistenceService = dataPersistenceService;
            _logger = logger;
        }
        public bool isMutant(string[] dna)
        {
            try
            {
                bool dnaIsMutant;
                int sequencesFound = 0;
                checkIfDnaIsValid(dna);
                sequencesFound += findSequencesHorizontal(dna);
                if (sequencesFound < 2) sequencesFound += findSequenceVertical(dna);
                if (sequencesFound < 2) sequencesFound += findSequenceDiagonal(dna);
                dnaIsMutant = sequencesFound >= 2;
                saveDna(dna, dnaIsMutant);
                return dnaIsMutant;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private void checkIfDnaIsValid(string[] dna)
        {
            try
            {
                checkIfLettersAreAllowed(dna);
                checkIfDnaSequencesHaveTheSameLength(dna);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void checkIfLettersAreAllowed(string[] dna)
        {
            Regex regex = new Regex("[^ATCG]");
            string joinArrayInString = string.Concat(dna).ToUpper();
            if (regex.Matches(joinArrayInString).Count != 0)
            {
                throw new Exception("only ATCG are allowed");
            }
        }
        private void checkIfDnaSequencesHaveTheSameLength(string[] dna)
        {
            int expectedLength = dna[0].Length * dna.Length;
            string joinArrayInString = string.Concat(dna).ToUpper();
            if (joinArrayInString.Length != expectedLength)
            {
                throw new Exception("dna is invalid");
            }
        }
        public int findSequencesHorizontal(string[] dna)
        {
            int sequencesFound = 0;
            for (int i = 0; i < dna.Length; i++)
            {
                string row = dna[i];
                sequencesFound += findSequenceByRows(row);
            }
            return sequencesFound;
        }

        private int findSequenceVertical(string[] dna)
        {
            int sequencesFound = 0;
            int lengthOneSequence = dna[0].Length;
            for (int i = 0; i < lengthOneSequence; i++)
            {
                StringBuilder row = new StringBuilder();
                for (int j = 0; j < lengthOneSequence; j++)
                {
                    char letter = dna[j][i];
                    row.Append(letter);
                }
                sequencesFound += findSequenceByRows(row.ToString());
            }
            return sequencesFound;
        }

        private int findSequenceDiagonal(string[] dna)
        {
            int sequencesFound = 0;
            int withoutDiagonal = 3;
            int lengthOneSequence = dna[0].Length;
            int lengthLoopForFindDiagonals = lengthOneSequence - withoutDiagonal;
            int rowNumber = 0;
            for (int i = 0; i < lengthLoopForFindDiagonals; i++)
            {
                StringBuilder row = new StringBuilder();
                for (int j = i; j < lengthOneSequence; j++)
                {
                    char letter = dna[rowNumber][j];
                    row.Append(letter);
                    rowNumber++;
                }
                rowNumber = 0;
                sequencesFound += findSequenceByRows(row.ToString());
            }
            return sequencesFound;
        }

        private int findSequenceByRows(string row)
        {
            int numberOfMatchesToFind = 4;
            int sequencesFound = 0;
            int numberLoops = row.Length / numberOfMatchesToFind + 1;
            for (int i = 1; i < numberLoops; i++)
            {
                string sequence = getSequenceByFour(i, row);
                if (checkIfLetterAreSame("A", sequence)) sequencesFound++;
                if (checkIfLetterAreSame("T", sequence)) sequencesFound++;
                if (checkIfLetterAreSame("C", sequence)) sequencesFound++;
                if (checkIfLetterAreSame("G", sequence)) sequencesFound++;
            }
            return sequencesFound;
        }

        public string getSequenceByFour(int actualLoop, string sequence)
        {
            int numberOfMatchesToFind = 4;
            int finalString = actualLoop * numberOfMatchesToFind;
            int startOfString = finalString - 4;
            return sequence.Substring(startOfString, finalString - startOfString);
        }

        public bool checkIfLetterAreSame(string letterToCompare, string sequence)
        {
            int numberForBeSequence = 4;
            int countEqualsLetters = sequence.Count(x => x == char.Parse(letterToCompare));
            return countEqualsLetters == numberForBeSequence;
        }

        private void saveDna(string[] dna, bool isMutant)
        {
            _dataPersistenceService.saveDna(new Dna
            {
                DnaSequence = string.Concat(dna).ToUpper(),
                IsHuman = !isMutant,
                IsMutant = isMutant
            });
        }

    }

}

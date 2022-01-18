using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFramwork.Objects
{
    public static class PresetConfig
    {
        public static Config AppleId = new("APPLEID")
        {
            Words = new Config.WordsConfig(
                description: "3 words of between 5 and 7 letters from the english dictionary",
                dictionary: Config.WordsConfig.DictionaryOption.English,
                numberOfWords: 3,
                minimumLength: 5,
                maximumLength: 7),
            Transformations = new Config.TransformationsConfig(
                description: "EVERY word randomly CAPITALISED or NOT",
                caseTransformation: "EVERY word randomly CAPITOLISED or NOT"),
            Seperator = new Config.SeperatorConfig(
                description: "a character randomly chosen from the set:",
                type: "Random Character",
                separators: new List<char> { '-', ':', '.', ',' }),
            PaddingDigits = new Config.PaddingDigitsConfig(
                description: "2 digits before and after the words",
                digitsBefore: 2,
                digitsAfter: 2),
            Summary = new Config.SummaryConfig(
                structure: null,  // TODO
                minLength: 25,
                maxLength: 31,
                characterCoverage: null // TODO
                )
         };
    }

    public class Config
    {
        public string Name { get; set; }
        public string RegExValidationPattern { get; set; }
        public WordsConfig Words { get; set; }
        public TransformationsConfig Transformations { get; set; }
        public SeperatorConfig Seperator { get; set; }
        public PaddingDigitsConfig PaddingDigits { get; set; }
        //public PaddingSymbolsConfig PaddingSymbols { get; set; }
        //public LoadSaveConfig LoadSave { get; set; }
        public SummaryConfig Summary { get; set; }

        public Config(string name)
        {
            Name = name;
        }

        public class WordsConfig
        {
            public enum DictionaryOption { English };

            public string Description { get; set; } // TODO: automatically generate from below settings within SET
            public DictionaryOption Dictionary { get; set; }
            public int NumberOfWords { get; set; }
            public int MinimumLength { get; set; }
            public int MaximumLength { get; set; }

            public WordsConfig(string description, DictionaryOption dictionary, int numberOfWords, int minimumLength, int maximumLength)
            {
                Description = description;
                Dictionary = dictionary;
                NumberOfWords = numberOfWords;
                MinimumLength = minimumLength;
                MaximumLength = maximumLength;
            }

            // TODO: Validate values are within configurable ranges on SET
        }

        public class TransformationsConfig
        {
            public string Description { get; set; } // TODO: automatically generate from below settings within SET
            public string CaseTransformation { get; set; } // TODO: Create & use a enum with all options

            public TransformationsConfig(string description, string caseTransformation)
            {
                Description = description;
                CaseTransformation = caseTransformation;
            }
        }

        public class SeperatorConfig
        {
            public string Description { get; set; } // TODO: automatically generate from below settings within SET
            public string Type { get; set; }  // TODO: Create & use a enum with all options
            public List<char> Separators { get; set; }

            public SeperatorConfig(string description, string type, List<char> separators)
            {
                Description = description;
                Type = type;
                Separators = separators;
            }
        }

        public class PaddingDigitsConfig
        {
            public string Description { get; set; } // TODO: automatically generate from below settings within SET
            public int DigitsBefore { get; set; }
            public int DigitsAfter { get; set; }

            public PaddingDigitsConfig(string description, int digitsBefore, int digitsAfter)
            {
                Description = description;
                DigitsBefore = digitsBefore;
                DigitsAfter = digitsAfter;
            }

            // TODO: Validate values are within configurable ranges on SET
        }

        public class PaddingSymbolsConfig
        {
            // TODO... (like the others)
        }

        public class LoadSaveConfig
        {
            // TODO... (like the others)
        }

        public class SummaryConfig
        {
            public string[] Structure { get; set; }
            public int MinLength { get; set; }
            public int MaxLength { get; set; }

            public List<string> CharacterCoverage { get; set; } // TODO: Create & use a enum with all options

            public SummaryConfig(string[] structure, int minLength, int maxLength, List<string> characterCoverage)
            {
                Structure = structure;
                MinLength = minLength;
                MaxLength = maxLength;
                CharacterCoverage = characterCoverage;
            }
        }
    }
}
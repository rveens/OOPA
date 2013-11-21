using System;
using System.IO;
using System.Collections.Generic;

using Parser.IO.Parsing.Exceptions;


namespace Parser.IO.Parsing
{
    public abstract class CircuitFileParser
    {
        private const string CLASS_TAG = "CircuitFileParser";

        private const string COMMENT_TAG = "#";
        private const string PARAM_SPLIT_TAG = ":";
        private const string CODELINE_STOP_TAG = ";";


        public static void Parse(string filePath)
        {
            const string METHOD_TAG = "Parse";

            if (!File.Exists(filePath))
                throw new CircuitFileNotFoundException(CLASS_TAG, METHOD_TAG, "The file '" + filePath + "' was not found!");

            List<string> parsedNodes,
                         parsedEdges;

            ParseNodes(filePath, out parsedNodes, out parsedEdges);
        }


        private static void ParseNodes(string filePath, out List<string> parsedNodes, out List<string> parsedEdges)
        {
            const string METHOD_TAG = "ParseNodes";

            parsedNodes = new List<string>();
            parsedEdges = new List<string>();

            try
            {
                var streamReader = new StreamReader(filePath);
                var line = 1;

                string currentLine;
                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    #region Validate Circuit File-syntax

                    if (currentLine.StartsWith(COMMENT_TAG))
                        continue;

                    

                    #endregion

                    Console.WriteLine(currentLine);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

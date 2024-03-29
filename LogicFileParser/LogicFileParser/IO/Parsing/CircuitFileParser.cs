﻿#region Using Statements

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using Parser.IO.Parsing.Exceptions;

#endregion


namespace Parser.IO.Parsing
{
    /// <summary>
    /// Helps parsing Circuit Files to build a circuit.
    /// </summary>
    public abstract class CircuitFileParser
    {
        /**
         * The class tag, used for exceptions and debugging.
         */
        private const string CLASS_TAG = "CircuitFileParser";


        /**
         * The file's syntax tag for a comment line.
         */
        private const string COMMENT_TAG = "#";

        /**
         * The file's syntax tag for a split-tag to parameters.
         */
        private const string PARAM_SPLIT_TAG = ":";

        /**
         * The file's syntax tag for the end of a codeline.
         */
        private const string CODELINE_STOP_TAG = ";";


        /// <summary>
        /// Parses a Circuit File and builds a Circuit based on the file's data.
        /// </summary>
        /// <param name="filePath">The full path of the file to parse.</param>
        public static void /* List<Nodes> */ Parse(string filePath)
        {
            const string METHOD_TAG = "Parse";

            if (!File.Exists(filePath))
                throw new CircuitFileNotFoundException(CLASS_TAG, METHOD_TAG, "The file '" + filePath + "' was not found!");

            List<string> parsedNodes,
                         parsedEdges;

            ParseNodes(filePath, out parsedNodes, out parsedEdges);

            /* List<Node> nodes = new List<Node>(); */
            /* nodes = */
            BuildNodes(parsedNodes);

            /* return nodes; */
        }


        private static void ParseNodes(string filePath, out List<string> parsedNodes, out List<string> parsedEdges)
        {
            const string METHOD_TAG = "ParseNodes";

            parsedNodes = new List<string>();
            parsedEdges = new List<string>();

            try
            {
                var streamReader = new StreamReader(filePath);
                var line = 0;
                var nodeType = 0;

                Console.WriteLine("Parsed Nodes");

                string currentLine;
                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    line++;

                    #region Validate Circuit File's Syntax

                    if (currentLine.StartsWith(COMMENT_TAG))
                        continue;

                    if (string.IsNullOrEmpty(currentLine))
                    {
                        Console.WriteLine("\nParsed Edges");

                        nodeType = 1;
                        continue;
                    }

                    if (!currentLine.EndsWith(CODELINE_STOP_TAG))
                        throw new CircuitFileSyntaxException(CLASS_TAG, METHOD_TAG,
                                                             ("Expected a '" + CODELINE_STOP_TAG + "' at the end of line " + line + "."));

                    if (currentLine.Count(x => x == ':') > 1)
                        throw new CircuitFileSyntaxException(CLASS_TAG, METHOD_TAG,
                                                             ("Unexpected '" + PARAM_SPLIT_TAG + "' found at line " + line + "."));

                    #endregion

                    #region Process Retrieved Data

                    currentLine = currentLine.Replace(" ", string.Empty)
                                             .Replace("\t", string.Empty)
                                             .Replace(";", string.Empty);
                    currentLine = currentLine.Split(':')[1];

                    if (nodeType == 0)
                        parsedNodes.Add(currentLine);
                    else
                        parsedEdges.Add(currentLine);

                    #endregion

                    Console.WriteLine(currentLine);
                }
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exception.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void /* List<Node> */ BuildNodes(List<string> parsedNodes)
        {
            //TODO: Build all nodes here...

            for (int index = 0; index < parsedNodes.Count; index++)
            {
                /* Node node = FactoryMethod<string, Node>.create(parsedNodes[index]); */
            }
        }

        private static void CoupleNodes(/* List<Node> nodes, */ List<string> parsedEdges)
        {
            //TODO: Fix the coupling between the built nodes, to complete building the entire circuit.
        }
    }
}

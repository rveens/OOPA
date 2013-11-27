﻿#region Using Statements

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using OOPA.IO.Parsing.Exceptions;
using OOPA.Factory;

#endregion


namespace OOPA.IO.Parsing
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
        /// <returns>Returns the built circuit, parsed from the file.</returns>
        public static List<Node> Parse(string filePath)
        {
            const string METHOD_TAG = "Parse";

            if (!File.Exists(filePath))
                throw new CircuitFileNotFoundException(CLASS_TAG, METHOD_TAG, "The file '" + filePath + "' was not found!");

            List<string> parsedNodes,
                         parsedEdges;

            ParseNodes(filePath, out parsedNodes, out parsedEdges);

            var nodes = new List<Node>();
            nodes = BuildNodes(parsedNodes);

            CoupleNodes(nodes, parsedEdges);

            return nodes;
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

                    if (nodeType == 0)
                    {
                        currentLine = currentLine.Split(':')[1];
                        parsedNodes.Add(currentLine);
                    }
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

        private static List<Node> BuildNodes(List<string> parsedNodes)
        {
            List<Node> nodes = new List<Node>();

            for (int index = 0; index < parsedNodes.Count; index++)
            {
                var node = FactoryMethod<string, Node>.create(parsedNodes[index]);
                nodes.Add(node);
            }

            return nodes;
        }

        private static void CoupleNodes(List<Node> nodes, List<string> parsedEdges)
        {
            Console.WriteLine("\n*** Node information ***");

            for (int index = 0; index < nodes.Count; index++)
                Console.WriteLine(nodes[index].GetType().ToString());

            //TODO: Couple Nodes due parsedEdges parameter data...
        }
    }
}
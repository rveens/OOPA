#region Using Statements

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
    /// Helps parsing Circuit files to build a circuit.
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
        /// Parses a Circuit file and builds a Circuit based on the file's data.
        /// </summary>
        /// <param name="filePath">The full path of the file to parse.</param>
        /// <returns>Returns the built circuit, parsed from the file.</returns>
        public static Circuit Parse(string filePath)
        {
            const string METHOD_TAG = "Parse";

            if (!File.Exists(filePath))
                throw new CircuitFileNotFoundException(CLASS_TAG, METHOD_TAG, "The file '" + filePath + "' was not found!");

            List<string> parsedNodes,
                         parsedEdges;

            ParseNodes(filePath, out parsedNodes, out parsedEdges);

            var circuit = new Circuit();
            var nodes = BuildNodes(parsedNodes, new CircuitBindNodeVisitor(circuit));

            CoupleNodes(ref nodes, parsedEdges);

            return circuit;
        }


        /// <summary>
        /// Parses all nodes and edges from a Circuit file.
        /// </summary>
        /// <param name="filePath">The full path of the file to parse.</param>
        /// <param name="parsedNodes">A list containing all data of the retrieved nodes from the file.</param>
        /// <param name="parsedEdges">A list containing all data of the retrieved edges from the file.</param>
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

                Console.WriteLine(@"Parsed Nodes");

                string currentLine;
                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    line++;

                    #region Validate Circuit File's Syntax

                    if (currentLine.StartsWith(COMMENT_TAG))
                        continue;

                    if (string.IsNullOrEmpty(currentLine))
                    {
                        Console.WriteLine(@"Parsed Edges");

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
                        parsedNodes.Add(currentLine);
                    else
                        parsedEdges.Add(currentLine);

                    #endregion

                    Console.WriteLine(currentLine);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Builds all nodes due the retrieved nodes data from the Circuit File.
        /// </summary>
        /// <param name="parsedNodes">A list containing all data of the retrieved nodes from the Circuit file.</param>
        /// <param name="cbnv">The visitor used to bind the circuit nodes.</param>
        /// <returns>A dictionary containing all built nodes out of the retrieved nodes data from the Circuit file.</returns>
        private static Dictionary<string, Node> BuildNodes(IEnumerable<string> parsedNodes, CircuitBindNodeVisitor cbnv)
        {
            var nodes = new Dictionary<string, Node>();

            foreach (var parsedNode in parsedNodes)
            {
                var node = FactoryMethod<string, Node>.create(parsedNode.Split(':')[1]);
                
				node.accept(cbnv);
                nodes.Add(parsedNode.Split(':')[0].ToLower(), node);
            }

            return nodes;
        }

        /// <summary>
        /// Couples the built nodes with each other based on the outputs.
        /// </summary>
        /// <param name="nodes">The nodes built due the retrieved nodes data from the Circuit file.</param>
        /// <param name="parsedEdges">The retrieved edges data from the file.</param>
        private static void CoupleNodes(ref Dictionary<string, Node> nodes, IEnumerable<string> parsedEdges)
        {
            foreach (var parsedEdge in parsedEdges)
            {
                const string METHOD_TAG = "CoupleNodes";

                var currentNodeIndex = parsedEdge.Split(':')[0].ToLower();
                var splitEdgeParameters = parsedEdge.Split(':')[1]
                                                    .Split(',');

                try
                {
                    Node currentNode;
                    if (!nodes.TryGetValue(currentNodeIndex, out currentNode))
                        throw new CurrentNodeNotFoundException(CLASS_TAG, METHOD_TAG,
                            "No 'current' node was found with the key '" + currentNodeIndex + "'!");

                    #region Couple Nodes Due Parsed Edge Data

                    foreach (var splitEdgeParameter in splitEdgeParameters)
                    {
                        Node coupleNode;
                        if (!nodes.TryGetValue(splitEdgeParameter.ToLower(), out coupleNode))
                            throw new CoupleNodeNotFoundException(CLASS_TAG, METHOD_TAG,
                                "No 'couple' node was found with the key '" + splitEdgeParameter + "'!");

                        currentNode.AddOutput(coupleNode);
                    }
                    #endregion
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}

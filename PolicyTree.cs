/**
 *
 *   Class to read and write policy files
 *   Copyright (C) 2015  Kenneth Bogert, Ekhlas Sonu
 *
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 */

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace demo_gui
{
	public static class Util {
		public static void Tokenize(string str1, out List<string> tokens, char[] delimiterChars){
			string [] tok = str1.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
			tokens = new List<string>(tok);
		}
	}

	public class PolicyTreeNode{
		public uint numObservations;
		public int horizon;
		public int action;
		public List<PolicyTreeNode> children;


		public PolicyTreeNode(uint numObs){
			numObservations = numObs;
			horizon = -1;
			action = -1;
			children = new List<PolicyTreeNode> ();
		}

		public void readPolicyTreeNode(System.IO.StreamReader policyfile, int hor){
			horizon = hor;

			string fileLine;
			bool lineParsed = false;
			try {
				while (!lineParsed) {
					fileLine = policyfile.ReadLine ();
					int hashLocation = fileLine.IndexOf ("#");
					if (hashLocation > -1) {
						fileLine = fileLine.Substring (0, hashLocation);
					}
					if (fileLine.Length == 0) {
						continue;
					}
					lineParsed = true;
					List<string> tokens;
					char[] delimiter = { ' ', '\t', '\n', ':', '-', '>' };
					Util.Tokenize (fileLine, out tokens, delimiter);
				
					action = int.Parse (tokens [3]);
				
					if (horizon > 1) {
						for (int obs = 0; obs < numObservations; obs++) {
							PolicyTreeNode tempNode = new PolicyTreeNode (numObservations);
							children.Add (tempNode);
							tempNode.readPolicyTreeNode (policyfile, hor - 1);
						}
					}
				}
			} catch (IOException ex) {
				
			}
		}

		public int getAction(){
			return action;
		}

		public PolicyTreeNode getNextNode(int obs){
			if(children.Count == 0 || obs < 0 || obs > numObservations){
				return null;
			}
			else return children[obs];
		}

		public string printNode(int numTabSpace=1){
			StringWriter sw = new StringWriter ();
			sw.Write ("act ");sw.WriteLine(action);
			if(horizon > 1){
				if(children.Count == 0){
					Debug.WriteLine("Partial policy read.");
					return null;
				}
				for(int obs=0; obs < numObservations; obs++){
					for(int tSp=0; tSp < numTabSpace; tSp++){
						sw.Write("\t");
					}
					sw.Write(" -> ");sw.Write ("obs ");sw.Write (obs);sw.Write(" -> ");
					sw.Write (children[obs].printNode(numTabSpace+1));
				}
			}
			return sw.ToString ();
		}

	};

	public class PolicyTree{
		public PolicyTreeNode root;
		public uint horizon;
		public uint numObservations;

		public PolicyTree(){
			horizon = 0;
			numObservations = 0;
			root = new PolicyTreeNode(numObservations);
		}

		public void readPolicyTree(StreamReader policyfile){

			bool horizonParsed = false;
			bool numObsParsed = false;

			string fileLine;

			try {
				while ((!horizonParsed || !numObsParsed)) {
					fileLine = policyfile.ReadLine ();
					int hashLocation = fileLine.IndexOf ("#");
					if (hashLocation > -1) {
						fileLine = fileLine.Substring (0, hashLocation);
					}
				
					if (fileLine.Length == 0) {
						continue;
					}
						
					List<string> tokens;
					char[] delimiter = { ' ', '\t', '\n', ':', '-', '>' };
					Util.Tokenize (fileLine, out tokens, delimiter);
				
					if (tokens.Count == 0) {	//Empty Line... Never gonna happen
						continue;
					}
				
					if (String.Compare (tokens [0], "Horizon") == 0 || String.Compare (tokens [0], "HORIZON") == 0) {
						horizon = uint.Parse (tokens [1]);
						horizonParsed = true;
					} else if (String.Compare (tokens [0], "Observations") == 0 || String.Compare (tokens [0], "OBSERVATIONS") == 0) {
						numObservations = uint.Parse (tokens [1]);
						root.numObservations = numObservations;
						numObsParsed = true;
					}
				
				}
			} catch (IOException ex) {
				
			}
			if(!horizonParsed){
				Debug.WriteLine("No definition of Horizon in file");
				return;
			}
			if(!numObsParsed){
				Debug.WriteLine("No definition of Observations in file");
				return;
			}

			//Now read the policy tree:
			root.readPolicyTreeNode(policyfile, (int)horizon);

		}

		public string printTree(){
			StringWriter sw = new StringWriter ();

			sw.Write ("HORIZON: ");sw.WriteLine(horizon);
			sw.Write("OBSERVATIONS: ");sw.WriteLine(numObservations);
			sw.Write("Vector 0: -> ");
			sw.Write(root.printNode());
			return sw.ToString ();
		}

	};

}


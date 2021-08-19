using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the activityNotifications function below.
    static int activityNotifications(int[] ex, int d) {
        var arr = new int[200];
        var i = 0;
        for(; i < d; i++){
            arr[ex[i]]++;
        }

        var mid = (d+1)/2;
        var res = 0;
        i--;

        for(; i < ex.Length-1; i++){
            var counter = 0;
            var median = 0.0;
            for(int j = 0; j < arr.Length; j++){
                counter += arr[j];
                if(counter >= mid){
                    if(d%2 != 0){
                        median = j;
                    } else {
                        var k = j;
                        while(counter == mid){
                            counter += arr[++k];
                        }
                        //Console.WriteLine(j + " " + k);
                        median = (j + k) / 2.0;
                    }
                    break;
                }
            }
            
            //Console.WriteLine(median);

            if(ex[i+1] >= median*2)
                res++;

            var drop = ex[i-(d-1)];
            arr[drop]--;
            arr[ex[i+1]]++;
        }

        return res;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] expenditure = Array.ConvertAll(Console.ReadLine().Split(' '), expenditureTemp => Convert.ToInt32(expenditureTemp));
        int result = activityNotifications(expenditure, d);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

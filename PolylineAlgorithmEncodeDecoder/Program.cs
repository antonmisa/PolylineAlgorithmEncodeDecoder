using System.IO;
using System.Collections.Generic;

namespace PolylineAlgorithmEncodeDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                if ((args[0] == "/e") || (args[0] == "/encode"))
                {
                    if (File.Exists(args[1]))
                    {
                        List<CoordinateEntity> points = new List<CoordinateEntity>();

                        using (StreamReader file = new StreamReader(args[1]))
                        {
                            int lineNumber = 1;
                            double x = 0;
                            double y = 0;
                            string line = null;

                            while ((line = file.ReadLine()) != null)
                            {
                                string[] lineElements = line.Split(' ');

                                if (lineElements.Length > 1)
                                {
                                    if (double.TryParse(lineElements[0], out x))
                                    {
                                        if (double.TryParse(lineElements[1], out y))
                                        {
                                            points.Add(new CoordinateEntity(x, y));
                                        }
                                        else
                                        {
                                            System.Console.WriteLine("In string #" + lineNumber.ToString() + " could not convert Longitude to double.");
                                        }
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("In string #" + lineNumber.ToString() + " could not convert Latitude to double.");
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("In string #" + lineNumber.ToString() + " there is not enough arguments.");
                                }
                                lineNumber++;
                            }

                            if (points.Count == lineNumber)
                            {
                                string encodedPoints = PolylineAlgoritm.Encode(points);
                                string strNewFileName = Path.GetFileNameWithoutExtension(args[1]) + ".encoded." + Path.GetExtension(args[1]);
                                File.WriteAllText(strNewFileName, encodedPoints);
                            }
                        }
                        //PolylineAlgoritm.Encode()
                    }
                    else
                    {
                        System.Console.WriteLine("File for encoding does not exist.");
                    }
                }
                else if ((args[0] == "/d") || (args[0] == "/decode"))
                {
                    if (File.Exists(args[1]))
                    {
                        string strFileContent = File.ReadAllText(args[1]);
                        IEnumerable<CoordinateEntity> points = PolylineAlgoritm.Decode(strFileContent);

                        string strNewFileName = Path.GetFileNameWithoutExtension(args[1]) + ".decoded." + Path.GetExtension(args[1]);
                        using (StreamWriter file = new StreamWriter(strNewFileName))
                        {
                            foreach(CoordinateEntity point in points)
                            {
                                file.WriteLine(point.Latitude.ToString() + " " + point.Longitude.ToString());
                            }
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("File for decoding does not exist.");
                    }
                }
                else
                {
                    System.Console.WriteLine("Unknown arguments for start working.");
                }
            }
            else if (args.Length > 2)
            {
                System.Console.WriteLine("Too much arguments for start working.");
            }
            else
            {
                System.Console.WriteLine("Please enter command and path to a decode/encode file.");
            }
        }
    }
}

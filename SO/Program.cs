using ConsoleApp1.SO;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SO
{
    public class Program
    {
        #region extension

        private static void StringExtensionTest()
        {
            var S = "sadadad";
            Console.WriteLine(S.Length());
            Console.WriteLine(S.Length(2));
        }

        #endregion extension
        #region OOP

        public abstract class classAB
        {
            public abstract void xxx();

            public void abc()
            {
            }

        }

        public class A
        {
            public virtual void Hehe()
            {
                Console.WriteLine("A nef");
            }
        }

        public class B : A
        {
            public override void Hehe()
            {
                Console.WriteLine("B nef");
            }
        }

        public class C : A
        {

        }

        public static void testVoid(A a)
        {
            Console.WriteLine(a);
            a.Hehe();
        }

        #endregion

        #region XMLSerialize

        [Serializable]
        public class ItemEntry
        {
            public string Name;
            public string Data;
            public int Amount;

            //parameterless constructor for XmlSerializer
            public ItemEntry()
            {
            }

            public ItemEntry(string iName, string idata, int iAmount)
            {
                Name = iName;
                Data = idata;
                Amount = iAmount;
            }
        }

        [Serializable]
        public class ItemDatabase
        {
            public List<ItemEntry> list = new List<ItemEntry>();

            public ItemDatabase()
            {
            }
        }

        public static void SaveItems(ItemDatabase itemDb)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
            FileStream stream = new FileStream("D:\\CraftedComp.xml", FileMode.Create);
            serializer.Serialize(stream, itemDb);
            stream.Close();
        }

        private static ItemDatabase CreatItemDataBase()
        {
            var item = new ItemDatabase();

            for (var i = 0; i < 10; i++)
            {
                item.list.Add(new ItemEntry("name" + i, "data" + i, i));
            }

            return item;
        }

        private static void testXML()
        {
            string mathMLResult = @"<math xmlns='bla'>
                            <SnippetCode>
                              testcode1
                            </SnippetCode>
                        </math>";

            XDocument xml = XDocument.Parse(mathMLResult);
            XElement mathNode = xml.Descendants().FirstOrDefault(x => x.Name.LocalName == "math");
            IEnumerable<XElement> mathNode1 = xml.Descendants("bla" + "math");

            // error occurres in this line
            List<XNode> childNodes = mathNode.Nodes().ToList();

            XElement mrow = new XElement("mrow");
            mrow.Add(childNodes);
            mathNode.RemoveNodes();
            XElement mstyle = new XElement("mstyle");
            XElement semantics = new XElement("semantics");
            XElement annotation = new XElement("annotation",
                new XAttribute("encoding", @"\&quot;application/x-tex\&quot;"));
            semantics.Add(mrow);
            semantics.Add(annotation);
            mstyle.Add(semantics);
            mathNode.Add(mstyle);
            var s = mathNode.ToString();

            Console.WriteLine(s);
        }

        #endregion

        #region properties testing

        public class ApplicationUser
        {


        }

        public class Article
        {


            public ApplicationUser CreatedBy { get; set; }
        }

        #endregion

        #region csvreading

        public class Patient
        {
            public string PatientID;
            public string DateOfBirth;
            public string DateFirstSeen;
            public string DateOfDiagnosis;
            public string TreatmentStartDate;
            public string TreatmentEndDate;
            public string CancerType;
            public string TreatmentType;
        }

        public static List<Patient> LoadPatients(string filePath)
        {
            var list = new List<Patient>();
            string[] LinesInFile = File.ReadAllLines("D:\\Book.csv");

            foreach (string line in LinesInFile)
            {
                if (line != "")
                {

                    string[] columns = line.Split(',');

                    list.Add(new Patient
                    {
                        PatientID = columns[0],
                        DateOfBirth = columns[1],
                        DateFirstSeen = columns[2],
                        DateOfDiagnosis = columns[3],
                        TreatmentStartDate = columns[4],
                        TreatmentEndDate = columns[5],
                        CancerType = columns[6],
                        TreatmentType = columns[7]
                    });
                }
            }

            return list;
        }

        public static Patient GetPatient(List<Patient> patients, string patientId)
        {
            return patients.FirstOrDefault(pt => pt.PatientID.Equals(patientId));
        }

        public static void PrintPatient(List<Patient> patients, string patientId)
        {
            GetPatient(patients, patientId);



        }

        static int hamming_distance(int x, int y)
        {
            int dist = 0;
            int val = x ^ y;

            // Count the number of bits set
            while (val != 0)
            {
                // A bit is set, so increment the count and clear the bit
                dist++;
                val &= val - 1;
            }

            // Return the number of differing bits
            return dist;
        }

        #endregion

        private static string lines = @"<div>&nbsp;</div><div>&nbsp;</div><p>&nbsp;</p><br />this is the input to keep<div>&nbsp;</div><br /><div>&nbsp;</div><p>&nbsp;</p><div>&nbsp;</div>";
        public static string RemoveStartAndEndBreaks(string input)
        {
            var lineBreaks = new[] { "<br>", "<br/>", "<br />", "<p></p>", "<p> </p>", "<p>&nbsp;</p>", "<div></div>", "<div> </div>", "<div>&nbsp;</div>" };

            var isMatched = true;

            while (isMatched)
            {
                foreach (var lb in lineBreaks)
                {
                    if (input.StartsWith(lb))
                    {
                        input = input.Substring(lb.Length);
                        isMatched = true;
                        break;
                    }

                    if (input.EndsWith(lb))
                    {
                        input = input.Substring(0, input.Length - lb.Length);
                        isMatched = true;
                        break;
                    }

                    isMatched = false;
                }
            }

            return input;
        }

        public class Setting
        {
            public string Name;
            public bool IsSelected;
        }

        private static void ReadAndWriteFile()
        {
            var path = @"D:\TextFile.txt";

            //Read all text lines first
            string[] readText = File.ReadAllLines(path);

            //Open the text file to write
            var oStream = new FileStream(path, FileMode.Truncate, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new System.IO.StreamWriter(oStream);


            bool inRewriteBlock = false;

            foreach (var s in readText)
            {
                if (s.Trim() == "#Start")
                {
                    inRewriteBlock = true;
                    sw.WriteLine(s);
                }
                else if (s.Trim() == "#End")
                {
                    inRewriteBlock = false;
                    sw.WriteLine(s);
                }
                else if (inRewriteBlock)
                {
                    //REWRITE DATA HERE (IN THIS CASE IS DELETE LINE THEN DO NOTHING)
                }
                else
                {
                    sw.WriteLine(s);
                }
            }

            sw.Close();
        }

        #region RSA encrypt
        public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Import the RSA Key information. This only needs
                    //toinclude the public key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Encrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }

        public static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    //Import the RSA Key information. This needs
                    //to include the private key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }

        }
        #endregion
        public const string LoginAdNotFound =
            "Login AD {0} with user {1} success but the user infomation not found on the current directory";

        #region Concurrence Perfomances

        private static void Dictionaries()
        {
            const int N = 10000000;
            var dict = new Dictionary<int, int>();
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < N; i++)
            {
                dict.Add(i, 0);
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine($"Dictionary adding time:{elapsedMs}");

            var cDict = new ConcurrentDictionary<int, int>();
            watch = Stopwatch.StartNew();
            for (int i = 0; i < N; i++)
            {
                cDict.TryAdd(i, 0);
            }
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine($"Concurrent dictionary adding time:{elapsedMs}");

            watch = Stopwatch.StartNew();
            for (int i = 0; i < N; i++)
            {
                var i1 = dict[i];
            }
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine($"dictionary get time:{elapsedMs}");

            watch = Stopwatch.StartNew();
            for (int i = 0; i < N; i++)
            {
                var i1 = cDict[i];
            }
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine($"Concurrent dictionary get time:{elapsedMs}");
        }


        #endregion Concurrence Perfomances
        [STAThread]
        public static void Main(string[] args)
        {
            XMLReading.CommentOutXML("XMLFile1.xml", "XMLFile1.xml");
        }
        #region SerializeDictionary
        public static Dictionary<string, string> Dict = new Dictionary<string, string>
        {
            {"GEN", "-"},
            {"TUR", "Turtle"},
            {"MAN", "Manual"},
            {"PRO", "Procedure"},
            {"WI", "Work Instruction"},
            {"TPL", "Template"},
            {"ADD", "Addendum"},
            {"TRA", "Training"},
            {"TOOL", "Tool"},
        };

        public static void SerializeDictionary()
        {
            var root = new XElement("ProcessArea",
                from keyValue in Dict
                select new XElement(keyValue.Key, keyValue.Value)
            );
            Console.WriteLine(root);
        }
        #endregion
    }
}


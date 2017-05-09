using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileHelpers;
using TechnicalAssessmentExtension.Helpers;

namespace TechnicalAssessmentExtension
{
    public class ProcessTechnicalAssessment
    {
        public ProcessTechnicalAssessment()
        {
            Clients = new List<Client>();
        }
        public IEnumerable<Client> Clients;
        private const string OuputDir = "Output";
        private const string FileOutput1 = "Output1.txt";
        private const string FileOutput2 = "Output2.txt";

        public void Process()
        {
            if (!Directory.Exists(OuputDir))
            {
                Directory.CreateDirectory(OuputDir);
            }
            string path = $@"{OuputDir}\{FileOutput1}";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            string path1 = $@"{OuputDir}\{FileOutput2}";
            if (File.Exists(path1))
            {
                File.Delete(path1);
            }

            DeserializeCsvFile();
            ProcessOutputFile1();
            ProcessOutputFile2();
        }

        public void ProcessOutputFile2()
        {
            using (StreamWriter wr = new StreamWriter($@"{OuputDir}\{FileOutput2}", true))
            {
                string header = "Addresses order by StreetName asc (not by Street Number)";
                Console.WriteLine(header);
                wr.WriteLine(header);
                var streetNameRecs = Clients.OrderBy(x => x.Address.Street).Select(x => x.Address.FullAddress).ToList();

                foreach (var streetNameRec in streetNameRecs)
                {
                    Console.WriteLine(streetNameRec);
                    wr.WriteLine(streetNameRec);
                }
                Console.WriteLine("\n");
                wr.WriteLine("\n");
            }

        }

        public void ProcessOutputFile1()
        {
            string header = "Frequency of Firstnames order by Frequency Desc.";

            using (StreamWriter wr = new StreamWriter($@"{OuputDir}\{FileOutput1}", true))
            {
                var firstNameFreqRecs = Clients.GroupBy(client => client.FirstName)
                .Select(group => new
                {
                    FirstName = group.Key,
                    Frequency = group.Count()
                })
                .OrderByDescending(x => x.Frequency).ToList();

                Console.WriteLine(header);
                wr.WriteLine(header);
                foreach (var firstNameFreqRec in firstNameFreqRecs)
                {
                    Console.WriteLine($"{firstNameFreqRec.FirstName},{firstNameFreqRec.Frequency}");
                    wr.WriteLine($"{firstNameFreqRec.FirstName},{firstNameFreqRec.Frequency}");
                }
                Console.WriteLine("\n");
                wr.WriteLine("\n");

                var lastNameFreqRecs = Clients.GroupBy(client => client.LastName)
                    .Select(group => new
                    {
                        LastName = group.Key,
                        Frequency = group.Count()
                    })
                    .OrderByDescending(x => x.Frequency).ToList();

                header = "Frequency of LastNames order by Frequency Desc.";
                Console.WriteLine(header);
                wr.WriteLine(header);
                foreach (var lastNameFreqRec in lastNameFreqRecs)
                {
                    Console.WriteLine($"{lastNameFreqRec.LastName},{lastNameFreqRec.Frequency}");
                    wr.WriteLine($"{lastNameFreqRec.LastName},{lastNameFreqRec.Frequency}");
                }

                Console.WriteLine("\n");
                wr.WriteLine("\n");

                var firstNamesAcs = firstNameFreqRecs.OrderBy(x => x.FirstName).ToList();
                header = "FirstNames order by FirstName asc";

                Console.WriteLine(header);
                wr.WriteLine(header);
                foreach (var firstName in firstNamesAcs)
                {
                    Console.WriteLine($"{firstName.FirstName},{firstName.Frequency}");
                    wr.WriteLine($"{firstName.FirstName},{firstName.Frequency}");
                }

                Console.WriteLine("\n");
                wr.WriteLine("\n");

                var lastNamesAcs = lastNameFreqRecs.OrderBy(x => x.LastName).ToList();

                header = "LastNames order by LastName asc";

                Console.WriteLine(header);
                wr.WriteLine(header);
                foreach (var lastName in lastNamesAcs)
                {
                    Console.WriteLine($"{lastName.LastName},{lastName.Frequency}");
                    wr.WriteLine($"{lastName.LastName},{lastName.Frequency}");
                }

                Console.WriteLine("\n");
                wr.WriteLine("\n");
            }

        }

        public void DeserializeCsvFile()
        {
            var engine = new FileHelperEngine<Client>();

            Clients = engine.ReadFile(@"Data\data.csv").AsEnumerable();
        }
    }
}

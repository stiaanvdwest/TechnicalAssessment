using System;
using TechnicalAssessmentExtension;

namespace TechnicalAssessment
{
    public class Program
    {
        static void Main()
        {
            try
            {
                ProcessTechnicalAssessment processTechnicalAssessment = new ProcessTechnicalAssessment();
                processTechnicalAssessment.Process();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

       
    }




}

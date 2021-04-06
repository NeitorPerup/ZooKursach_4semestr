using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Wordprocessing;

namespace UrskiyPeriodBusinessLogic.HelperModels
{
    public class WordTextProperties
    {
        public string Size { get; set; }

        public bool Bold { get; set; }

        public JustificationValues JustificationValues { get; set; }
    }
}

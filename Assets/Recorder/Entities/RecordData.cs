using System;
using System.Collections.Generic;
using Assets.Recorder.DataModels;

namespace Recorder.Entities
{
    [Serializable]
    public class Data
    {

        internal List<Record> RecordsSequence { get; set; }
        public Data()
        {
            RecordsSequence = new List<Record>();
        }

        
    }
}

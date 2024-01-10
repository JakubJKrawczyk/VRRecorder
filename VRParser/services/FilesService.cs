using System.Globalization;
using CsvHelper;
using VRParser.Entities;
using VRParser.GlobalClasses;

namespace VRParser.services;

public static class FilesService
{
    public static async Task ConvertFileToObject()
    {
        if (GlobalVariables.ImportedFile is not null)
        {
            
                TextReader reader = null;
                try
                {

                     reader = new StreamReader(GlobalVariables.ImportedFile.OpenReadStream());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                if (reader is not null)
                {
                    
                    CsvReader csvReader = new(reader, CultureInfo.InvariantCulture);
                    try
                    {
                        List<Record> serializedAsync = new();
                        await foreach (var record in csvReader.GetRecordsAsync<Record>())
                        {
                            serializedAsync.Add(record);
                        }
                        
                        GlobalVariables.ImportedMatrice = new()
                        {
                            RecordsSequence = serializedAsync
                        };

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    
                }
            
        }
    }

    


    
    
}
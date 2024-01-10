using Microsoft.AspNetCore.Components.Forms;
using VRParser.Entities;

namespace VRParser.GlobalClasses;

public class GlobalVariables
{
    public static IBrowserFile ImportedFile {
        get;
        set;
    }

    public static MatriceModel ImportedMatrice { get; set; }
}
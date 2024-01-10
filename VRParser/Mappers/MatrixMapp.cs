using CsvHelper.Configuration;
using VRParser.Entities;

namespace VRParser.Mappers;

public class MatrixMapp : ClassMap<Record>
{
    public MatrixMapp()
    {
            Map(x => x.Head.H_PosX).Name("awesome");
            Map(x => x.Head.H_PosY);
            Map(x => x.Head.H_PosZ);
            Map(x => x.Head.H_RotX);
            Map(x => x.Head.H_RotY);
            Map(x => x.Head.H_RotZ);

            //Left Controller
            Map(x => x.LeftController.L_ButtonXPressed);
            Map(x => x.LeftController.L_ButtonXTouched);
            Map(x => x.LeftController.L_ButtonYPressed);
            Map(x => x.LeftController.L_ButtonYTouched);
            Map(x => x.LeftController.L_ButtonMenuPressed);
            Map(x => x.LeftController.L_TrigPressed);
            Map(x => x.LeftController.L_TrigTouched);
            Map(x => x.LeftController.L_TrigValue);
            Map(x => x.LeftController.L_GripPressed);
            Map(x => x.LeftController.L_JoyPressed);
            Map(x => x.LeftController.L_JoyTouched);
            Map(x => x.LeftController.L_JoyX);
            Map(x => x.LeftController.L_JoyY);
            Map(x => x.LeftController.L_PosX);
            Map(x => x.LeftController.L_PosY);
            Map(x => x.LeftController.L_PosZ);
            Map(x => x.LeftController.L_RotX);
            Map(x => x.LeftController.L_RotY);
            Map(x => x.LeftController.L_RotZ);
            //Right Controller
            Map(x => x.RightController.R_BtnAPressed);
            Map(x => x.RightController.R_BtnATouched);
            Map(x => x.RightController.R_BtnBPressed);
            Map(x => x.RightController.R_BtnBTouched);
            Map(x => x.RightController.R_BtnSysPress);
            Map(x => x.RightController.R_TrigPressed);
            Map(x => x.RightController.R_TrigTouched);
            Map(x => x.RightController.R_TrigValue);
            Map(x => x.RightController.R_GripPressed);
            Map(x => x.RightController.R_JoyPressed);
            Map(x => x.RightController.R_JoyTouched);
            Map(x => x.RightController.R_JoyX);
            Map(x => x.RightController.R_JoyY);
            Map(x => x.RightController.R_PosX);
            Map(x => x.RightController.R_PosY);
            Map(x => x.RightController.R_PosZ);
            Map(x => x.RightController.R_RotX);
            Map(x => x.RightController.R_RotY);
            Map(x => x.RightController.R_RotZ);


            Map(x => x.TimeSpan);
    }
}
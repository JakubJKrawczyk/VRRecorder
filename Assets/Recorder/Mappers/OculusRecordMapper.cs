using Assets.Recorder.DataModels;
using CsvHelper;
using CsvHelper.Configuration;

namespace Assets.Recorder.Mappers
{
    internal class OculusRecordMapper
    {
        internal static ClassMap CreateMap()
        {
            var _factory = new Factory();

            var _mapper = _factory.CreateClassMapBuilder<Record>();
            //Head Controller
            _mapper.Map(x => x.Head.H_PosX);
            _mapper.Map(x => x.Head.H_PosY);
            _mapper.Map(x => x.Head.H_PosZ);
            _mapper.Map(x => x.Head.H_RotX);
            _mapper.Map(x => x.Head.H_RotY);
            _mapper.Map(x => x.Head.H_RotZ);

            //Left Controller
            _mapper.Map(x => x.LeftController.L_ButtonXPressed);
            _mapper.Map(x => x.LeftController.L_ButtonXTouched);
            _mapper.Map(x => x.LeftController.L_ButtonYPressed);
            _mapper.Map(x => x.LeftController.L_ButtonYTouched);
            _mapper.Map(x => x.LeftController.L_ButtonMenuPressed);
            _mapper.Map(x => x.LeftController.L_TrigPressed);
            _mapper.Map(x => x.LeftController.L_TrigTouched);
            _mapper.Map(x => x.LeftController.L_TrigValue);
            _mapper.Map(x => x.LeftController.L_GripPressed);
            _mapper.Map(x => x.LeftController.L_JoyPressed);
            _mapper.Map(x => x.LeftController.L_JoyTouched);
            _mapper.Map(x => x.LeftController.L_JoyX);
            _mapper.Map(x => x.LeftController.L_JoyY);
            _mapper.Map(x => x.LeftController.L_PosX);
            _mapper.Map(x => x.LeftController.L_PosY);
            _mapper.Map(x => x.LeftController.L_PosZ);
            _mapper.Map(x => x.LeftController.L_RotX);
            _mapper.Map(x => x.LeftController.L_RotY);
            _mapper.Map(x => x.LeftController.L_RotZ);
            //Right Controller
            _mapper.Map(x => x.RightController.R_BtnAPressed);
            _mapper.Map(x => x.RightController.R_BtnATouched);
            _mapper.Map(x => x.RightController.R_BtnBPressed);
            _mapper.Map(x => x.RightController.R_BtnBTouched);
            _mapper.Map(x => x.RightController.R_BtnSysPress);
            _mapper.Map(x => x.RightController.R_TrigPressed);
            _mapper.Map(x => x.RightController.R_TrigTouched);
            _mapper.Map(x => x.RightController.R_TrigValue);
            _mapper.Map(x => x.RightController.R_GripPressed);
            _mapper.Map(x => x.RightController.R_JoyPressed);
            _mapper.Map(x => x.RightController.R_JoyTouched);
            _mapper.Map(x => x.RightController.R_JoyX);
            _mapper.Map(x => x.RightController.R_JoyY);
            _mapper.Map(x => x.RightController.R_PosX);
            _mapper.Map(x => x.RightController.R_PosY);
            _mapper.Map(x => x.RightController.R_PosZ);
            _mapper.Map(x => x.RightController.R_RotX);
            _mapper.Map(x => x.RightController.R_RotY);
            _mapper.Map(x => x.RightController.R_RotZ);


            _mapper.Map(x => x.TimeSpan);

            return _mapper.Build();
        }
    }
}
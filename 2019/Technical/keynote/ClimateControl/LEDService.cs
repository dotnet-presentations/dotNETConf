//using PiTop;
//using PiTopMakerArchitecture.Foundation;
//using PiTopMakerArchitecture.Foundation.Components;

namespace ClimateControl
{
    public class LEDService
    {
        //PiTopModule _module;
        //FoundationPlate _plate;
        //private Led _green;
        //private Led _amber;
        //private Led _red;

        public LEDService()
        {
            //_module = new PiTopModule();

            //_plate = _module.GetOrCreatePlate<FoundationPlate>();

            //_green = _plate.GetOrCreateDevice<Led>(DigitalPort.D0);
            //_green.DisplayProperties.Add(new NamedCssColor("green"));

            //_amber = _plate.GetOrCreateDevice<Led>(DigitalPort.D1);
            //_amber.DisplayProperties.Add(new NamedCssColor("gold"));

            //_red = _plate.GetOrCreateDevice<Led>(DigitalPort.D2);
            //_red.DisplayProperties.Add(new NamedCssColor("red"));
        }

        private void DisableAllLeds()
        {
            //_green.Off();
            //_amber.Off();
            //_red.Off();
        }

        //private void Toggle(Led led, bool isOn)
        //{
        //    DisableAllLeds();

        //    if (!isOn)
        //    {
        //        led.Off();
        //    }
        //    else
        //    {
        //        led.On();
        //    }
        //}

        //public void ToggleRed(bool isOn)
        //{
        //    Toggle(_red, isOn);
        //}

        //public void ToggleGreen(bool isOn)
        //{
        //    Toggle(_green, isOn);
        //}

        //public void ToggleGold(bool isOn)
        //{
        //    Toggle(_amber, isOn);
        //}
    }
}
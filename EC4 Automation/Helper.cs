using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;

namespace ExpenceItAutomation
{
    public static class ControlsHelper
    {
        public static void SetTextToTextbox(this TextBox textBox, string textToSet)
        {
            if (textBox != null)
            {

                textBox.SetValue(textToSet);
                Console.WriteLine("Text " + textToSet + " set to the " + textBox + " text box");
            }
            else
            {
                Console.WriteLine(textBox + " text box not found");
            }
        }

        public static void ComboBoxSelector(this ComboBox comboBox, string elementToSelect)
        {
            if (comboBox != null)
            {
                comboBox.Click();
                comboBox.Select(elementToSelect);
                Console.WriteLine(elementToSelect + " Selected");
            }
            else
            {
                Console.WriteLine(elementToSelect + " not found");
            }

        }

    }
}

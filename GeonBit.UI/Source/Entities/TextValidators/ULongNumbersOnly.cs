#region File Description
//-----------------------------------------------------------------------------
// Validators you can attach to TextInput entities to manipulate and validate
// user input. These are used to create things like text input for numbers only,
// limit characters to english chars, etc.
//
// Author: Ronen Ness.
// Since: 2016.
//-----------------------------------------------------------------------------
#endregion

namespace GeonBit.UI.Entities.TextValidators
{
    /// <summary>
    /// Make sure input is numeric and optionally validate min / max values.
    /// </summary>
    [System.Serializable]
    public class ULongNumbersOnly : ITextValidator
    {
        /// <summary>
        /// Static ctor.
        /// </summary>
        static ULongNumbersOnly()
        {
            Entity.MakeSerializable(typeof(ULongNumbersOnly));
        }

        /// <summary>
        /// Optional min value.
        /// </summary>
        public ulong? Min;

        /// <summary>
        /// Optional max value.
        /// </summary>
        public ulong? Max;

        /// <summary>
        /// Create the number validator.
        /// </summary>
        /// <param name="min">If provided, will force min value.</param>
        /// <param name="max">If provided, will force max value.</param>
        public ULongNumbersOnly(ulong? min = null, ulong? max = null)
        {
            Min = min;
            Max = max;
        }
        
        /// <summary>
        /// Return true if text input is a valid number.
        /// </summary>
        /// <param name="text">New text input value.</param>
        /// <param name="oldText">Previous text input value.</param>
        /// <returns>If TextInput value is legal.</returns>
        public override bool ValidateText(ref string text, string oldText)
        {
            // if string empty return true
            if (text.Length == 0)
            {
                return true;
            }

            // make sure no spaces
            if (text.Contains(' '))
            {
                return false;
            }

            // will contain value as number
            ulong num;
            
            if (!ulong.TryParse(text, out num))
            {
                return false;
            }
            
            // validate range
            if (Min != null && num < (ulong)Min) { text = Min.ToString(); }
            if (Max != null && num > (ulong)Max) { text = Max.ToString(); }

            // valid number input
            return true;
        }
    }
}
﻿using System.Collections.Generic;

namespace MBBSEmu.HostProcess.Fsd
{
    /// <summary>
    ///     FSD Field Specification Class
    /// </summary>
    public class FsdFieldSpec
    {
        /// <summary>
        ///     Field Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///     Minimum for the Input Field
        /// </summary>
        public int Minimum { get; set; }

        /// <summary>
        ///     Maximum for the Input Field
        /// </summary>
        public int Maximum { get; set; }

        /// <summary>
        ///     Specifies if the Field is Read-Only and cannot be selected
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        ///     Field Type for this Field
        /// </summary>
        public EnumFsdFieldType FsdFieldType { get; set; }

        /// <summary>
        ///     Specifies if spaces are allowed in this field
        /// </summary>
        public bool NoSpaces { get; set; }

        /// <summary>
        ///     List of Values for Multiple Choide/Drop Down Fields
        /// </summary>
        public List<string> Values { get; set; }

        /// <summary>
        ///     X Position of the Field on the Screen
        /// </summary> 
        public int X { get; set; }

        /// <summary>
        ///     Y Position of the Field on the Screen
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     Length of the Field as Defined in the Template
        /// </summary>
        public int FieldLength { get; set; }

        /// <summary>
        ///     Currently Selected Value (Multiple Choice)
        /// </summary>
        public int SelectedValue { get; set; }

        /// <summary>
        ///     ANSI Sequence for the Field when not actively selected
        /// </summary>
        public byte[] FieldAnsi { get; set; }

        /// <summary>
        ///     Specified Field Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///     This is the value that is saved when you enter a field, if validation fails it resets
        /// </summary>
        public string OriginalValue { get; set; }

        public FsdFieldSpec()
        {
            Values = new List<string>();
            FsdFieldType = EnumFsdFieldType.Text;
            Maximum = 20;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace GraphicNotes.Views.Objects
{
    class TextObject:BaseObject
    {
        static TextObject()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TextObject), new FrameworkPropertyMetadata(typeof(TextObject)));
        }
    }
}

/*  $Id: LevelEditorLabel.cs,v 1.1 2006/11/17 06:47:40 jenetic.bytemare Exp $
 *  =================================================================================
 *  The 3dsmax-loader.
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Classes
{
    public class LevelEditorLabel : Label
    {
        public LevelEditorLabel( string initText, Point initLocation, ContentAlignment initAlignment, Color initForeColor, Color initBackColor, Size initSize )
        : base()
        {
            Text        = initText;
            Location    = initLocation;
            TextAlign   = initAlignment;
            ForeColor   = initForeColor;
            BackColor   = initBackColor;
            Size        = initSize;

        } //endmethod
    } //endclass
} //endnamespace

/*
 *  $Log: LevelEditorLabel.cs,v $
 *  Revision 1.1  2006/11/17 06:47:40  jenetic.bytemare
 *  safe
 *
 *  Revision 1.1  2006/10/16 11:35:13  Mr. jenetic.bytemare
 *  editor makings
 *
 *  Revision 1.2  2006/10/12 14:12:10  Mr. jenetic.bytemare
 *  implemented directX sound-system
 *  levelEditor in progress
 *
 *  Revision 1.1  2006/10/31 03:16:10  Mr. jenetic.bytemare
 *  level-editor in progress
 *
 */

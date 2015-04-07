/*  $Id: LevelEditorButton.cs,v 1.1 2006/11/17 06:47:40 jenetic.bytemare Exp $
 *  =================================================================================
 *  The 3dsmax-loader.
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Classes
{
    public class LevelEditorButton : Button
    {
        public LevelEditorButton( string initText, Point initLocation, EventHandler initClickEvent )
        : base()
        {
            Text        = initText;
            Location    = initLocation;
            Click       += initClickEvent;

        } //endmethod
    } //endclass
} //endnamespace

/*
 *  $Log: LevelEditorButton.cs,v $
 *  Revision 1.1  2006/11/17 06:47:40  jenetic.bytemare
 *  safe
 *
 *  Revision 1.1  2006/10/16 14:19:33  Mr. jenetic.bytemare
 *  advanced 3dsmax-importer
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

/*  $Id: LevelEditor.cs,v 1.1 2006/11/17 06:48:04 jenetic.bytemare Exp $
 *  =================================================================================
 *  The 3dsmax-loader.
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Classes;

namespace LevelEditor
{
    public class LevelEditor
    {
        public static void Main()
        {
            //init form
            LevelEditorPanel.init();
            LevelEditorForm.init();
            TickerSystem.init();

            //start the thread
            Application.Run ( LevelEditorForm.levelEditorForm );

        } //endmain
    } //endclass
} //endnamespace

/*
 *  $Log: LevelEditor.cs,v $
 *  Revision 1.1  2006/11/17 06:48:04  jenetic.bytemare
 *  safe
 *
 *  Revision 1.3  2006/10/16 11:35:12  Mr. jenetic.bytemare
 *  editor makings
 *
 *  Revision 1.2  2006/10/12 14:12:09  Mr. jenetic.bytemare
 *  implemented directX sound-system
 *  levelEditor in progress
 *
 *  Revision 1.1  2006/10/31 03:16:10  Mr. jenetic.bytemare
 *  level-editor in progress
 *
 */

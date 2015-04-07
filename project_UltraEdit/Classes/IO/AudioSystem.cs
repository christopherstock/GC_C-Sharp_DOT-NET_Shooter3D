/*  $Id: AudioSystem.cs,v 1.1 2006/11/17 06:46:15 jenetic.bytemare Exp $
 *  ==================================================================================
 *  The audio-system.
 */

using System;
using System.Windows.Forms;
using CsGL.OpenGL;
using Classes.Game;
using Classes.Engine3D;
using Microsoft.DirectX.AudioVideoPlayback;

namespace Classes.IO
{
    public class AudioSystem
    {
        private static Audio    bgLoop      = null;
        public  static Audio    fx          = null;

        public static void startBgLoop()
        {
            switch ( Level.currentLevel )
            {
                case Level.LEVEL_1:
                {
                    bgLoop          =  new Audio( "audio/test2.mp3", true );
                    bgLoop.Ending   += new EventHandler( restartBgLoop );
                    break;
                } //endcase

            } //endswitch

        } //endmethod

        public static void restartBgLoop( object o, System.EventArgs e )
        {
            bgLoop.SeekCurrentPosition( 0, SeekPositionFlags.AbsolutePositioning );

        } //endmethod

    } //endclass
} //endnamespace

/*
 *  $Log: AudioSystem.cs,v $
 *  Revision 1.1  2006/11/17 06:46:15  jenetic.bytemare
 *  safe
 *
 *  Revision 1.1  2006/10/12 14:12:50  Mr. jenetic.bytemare
 *  implemented directX sound-system
 *  levelEditor in progress
 *
 *
 */

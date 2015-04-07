/*  $Id: FPS.cs,v 1.3 2006/11/17 06:46:14 jenetic.bytemare Exp $
 *  ==================================================================================
 *  Measures the frames per second.
 */

using System;

namespace Classes.EngineGame
{
    public class FPS
    {
        public  static  long    framesDrawn         = 0;
        public  static  long    secondsElapsed      = 0;
        public  static  long    startTime           = 0;

        public static void update()
        {
            secondsElapsed = ( ( DateTime.Now ).Ticks - startTime ) / 20000000;

            if ( secondsElapsed > 0 )
            {
                Console.WriteLine( "FPS: {0}", framesDrawn );
                framesDrawn = 0;
                startTime = ( DateTime.Now ).Ticks;
            } //endif
        } //endmethod

        public static void init()
        {
            startTime = ( DateTime.Now ).Ticks;
        } //endmethod
    } //endclass
} //endnamespace

/*
 *  $Log: FPS.cs,v $
 *  Revision 1.3  2006/11/17 06:46:14  jenetic.bytemare
 *  safe
 *
 *  Revision 1.3  2006/10/10 11:28:33  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.2  2006/10/04 21:10:05  jenetic.bytemare
 *  collisions in progress ..
 *
 *  Revision 1.1  2006/10/02 11:23:41  jenetic.bytemare
 *  completed 3dsmax-importer.
 *  rearranged packages.
 *
 *  Revision 1.1  2006/10/01 19:01:44  jenetic.bytemare
 *  loader for importing 3dsmax-meshes in progress
 *  implemented strafing
 *  implemented frames-per-second debugging
 *
 *
 */

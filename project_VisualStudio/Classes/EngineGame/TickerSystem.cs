/*  $Id: TickerSystem.cs,v 1.8 2006/11/17 06:46:14 jenetic.bytemare Exp $
 *  ==================================================================================
 *  Defines the threaded operations.
 */

using System;
using System.Windows.Forms;
using Classes.Game;
using Classes.Engine3D;
using Classes.IO;

namespace Classes.EngineGame
{
    public class TickerSystem : Timer
    {
        private const   int             DELAY           = 25;
        public  static  TickerSystem    tickerSystem    = null;

        public TickerSystem()
        {
            Interval = DELAY;
            Tick     += new EventHandler( run );
            Start();

        } //endmethod

        public static void init()
        {
            tickerSystem = new TickerSystem();
        } //endmethod

        protected static void run( Object objSender, EventArgs e )
        {
            onRun();                                            //calculating
            Shooter3DForm.shooter3DForm.Refresh();              //refresh drawing GL

            //outsource this please..!

            //debug performance
            if ( Shooter3D.Shooter3D.DEBUG_PERFORMANCE )
            {
                FPS.framesDrawn++;
                FPS.update();
            } //endif
        } //endmethod

        private static void onRun()
        {
            //assign new position if position will not be changed
            Character.newPosX = Character.posX;
            Character.newPosZ = Character.posZ;

            //process the game-keys
            KeySystem.processGameKey();

            //check for collisions
            Character.proceedToNewPosition();

            //check for special-regions
            Character.checkSpecialRegions();

            //Console.WriteLine("posX: {0} posY: {1} posZ: {2}", Character.posX, Character.posY, Character.posZ );
            //Console.WriteLine("rotX: {0} rotY: {1} rotZ: {2}", Character.rotX, Character.rotY, Character.rotZ );
            //Console.WriteLine( " player located on col {0} row {1} ", (int)( Character.posX / Cell.CELL_WIDTH ), (int)( Character.posZ / Cell.CELL_HEIGHT ) );

        } //endmethod
    } //endclass
} //endnamespace

/*
 *  $Log: TickerSystem.cs,v $
 *  Revision 1.8  2006/11/17 06:46:14  jenetic.bytemare
 *  safe
 *
 *  Revision 1.5  2006/10/31 01:27:25  Mr. jenetic.bytemare
 *  new meshes
 *
 *  Revision 1.4  2006/10/31 00:03:18  Mr. jenetic.bytemare
 *  completed descending walls - fixed a bug
 *
 *  Revision 1.3  2006/10/10 11:28:33  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.7  2006/10/09 17:26:22  jenetic.bytemare
 *  elevated floors completed
 *
 *  Revision 1.6  2006/10/04 21:10:05  jenetic.bytemare
 *  collisions in progress ..
 *
 *  Revision 1.5  2006/10/03 13:42:19  jenetic.bytemare
 *  completed floor-texturing
 *
 *  Revision 1.4  2006/10/02 21:54:59  jenetic.bytemare
 *  implemented point-colliding
 *  region-colliding in progress
 *
 *  Revision 1.3  2006/10/02 18:40:23  jenetic.bytemare
 *  2d-array and collisions completed
 *
 *  Revision 1.2  2006/10/02 12:07:59  jenetic.bytemare
 *  2d-collision-level-system in progress
 *
 *  Revision 1.1  2006/10/02 11:23:41  jenetic.bytemare
 *  completed 3dsmax-importer.
 *  rearranged packages.
 *
 *  Revision 1.6  2006/10/01 19:01:00  jenetic.bytemare
 *  implemented strafing
 *  implemented frames-per-second debugging
 *
 *  Revision 1.5  2006/10/01 15:45:09  jenetic.bytemare
 *  3dsmax import in progress
 *
 *  Revision 1.4  2006/10/01 10:07:22  jenetic.bytemare
 *  pruned present code
 *  created class character
 *
 *  Revision 1.3  2006/09/29 21:07:56  jenetic.bytemare
 *  implemented multiple textures
 *
 *  Revision 1.2  2006/09/29 17:13:57  jenetic.bytemare
 *  implemented level-data
 *
 *  Revision 1.1  2006/09/29 14:15:56  jenetic.bytemare
 *  outsourcing key-system in progress
 *
 *
 */

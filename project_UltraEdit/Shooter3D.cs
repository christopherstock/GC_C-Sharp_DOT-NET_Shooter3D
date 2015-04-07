/*  $Id: Shooter3D.cs,v 1.14 2006/11/17 06:46:13 jenetic.bytemare Exp $
 *  =================================================================================
 *  The main-class.
 */

using System;
using System.Windows.Forms;

using Classes.EngineGame;
using Classes.Engine3D;
using Classes.IO;
using Classes.Game;

namespace Shooter3D
{
	public class Shooter3D
	{
	    //debug-switches
	    public  static  bool    DEBUG_PERFORMANCE = false;

		static void Main()
		{
            //initialize all systems
            Shooter3DForm.init();
            OpenGLControlView.init();
            TickerSystem.init();
            Texture.init();

            //setup level
            Level.init();
            Character.init();

            if ( DEBUG_PERFORMANCE )
            {
                //init the FPS
                FPS.init();
            } //endif

            //start the thread
            Application.Run ( Shooter3DForm.shooter3DForm );

		} //endmethod
	} //endclass
} //endnamespace

/*
 *  $Log: Shooter3D.cs,v $
 *  Revision 1.14  2006/11/17 06:46:13  jenetic.bytemare
 *  safe
 *
 *  Revision 1.3  2006/10/10 11:28:30  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.13  2006/10/05 19:05:26  jenetic.bytemare
 *  rearranged packages
 *  completed box-mesh
 *
 *  Revision 1.12  2006/10/04 21:10:04  jenetic.bytemare
 *  collisions in progress ..
 *
 *  Revision 1.11  2006/10/03 15:14:35  jenetic.bytemare
 *  tyding all classes
 *
 *  Revision 1.10  2006/10/03 13:42:18  jenetic.bytemare
 *  completed floor-texturing
 *
 *  Revision 1.9  2006/10/02 18:40:22  jenetic.bytemare
 *  2d-array and collisions completed
 *
 *  Revision 1.8  2006/10/02 11:23:40  jenetic.bytemare
 *  completed 3dsmax-importer.
 *  rearranged packages.
 *
 *  Revision 1.7  2006/10/02 10:23:34  jenetic.bytemare
 *  streaming 3dsmax texture-vertices and texture-faces
 *
 *  Revision 1.6  2006/10/01 21:01:03  jenetic.bytemare
 *  completed 3dsmax-importer [textures are to come!]
 *
 *  Revision 1.5  2006/10/01 19:01:00  jenetic.bytemare
 *  implemented strafing
 *  implemented frames-per-second debugging
 *
 *  Revision 1.4  2006/10/01 10:07:22  jenetic.bytemare
 *  pruned present code
 *  created class character
 *
 *  Revision 1.3  2006/09/29 21:07:54  jenetic.bytemare
 *  implemented multiple textures
 *
 *  Revision 1.2  2006/09/29 14:15:36  jenetic.bytemare
 *  outsourcing key-system in progress
 *
 *  Revision 1.1  2006/09/29 13:09:50  jenetic.bytemare
 *  initial commitment
 *  pruned present sources
 *
 */

/*  $Id: Character.cs,v 1.15 2006/11/17 06:46:14 jenetic.bytemare Exp $
 *  ==================================================================================
 *  Representing the character.
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Classes.Engine3D;
using Classes.Engine3D.MeshCollection;
using Classes.Engine3D.SolidMeshes;
using Classes.EngineGame;

namespace Classes.Game
{
    public class Character
    {
        public const    float           CHARACTER_DEPTH             = 0.25f;    //player's distance from floor
        public const    float           CHARACTER_RADIUS            = 0.125f;   //player's radius

        public const    float           CHARACTER_WALKING_SPEED     = 0.05f;    //walking speed
        public const    float           CHARACTER_STRAFING_SPEED    = 0.04f;    //strafing speed
        public const    float           CHARACTER_TURNING_SPEED     = 3.0f;     //turning speed in ° (left/right)
        public const    float           CHARACTER_COLLISION_STEPS   = 3.0f;     //steps of checking collisions on moving

        public const    float           CHARACTER_MAX_Y_VIEW        = 45.0f;    //max. look up/down in °
        public const    float           CHARACTER_LOOKING_SPEED     = 3.0f;     //looking speed in ° (up/down)
        public const    float           CHARACTER_WALKING_Y_SPEED   = 10.0f;    //y-modification per walking-step in °
        public const    float           CHARACTER_WALKING_Y_RATIO   = 25.0f;    //y-amplitude ratio

        public static   float           posX                        = 0.0f;     //current position X
        public static   float           posY                        = 0.0f;     //current position Y
        public static   float           posZ                        = 0.0f;     //current position Z

        public static   float           lastPosX                    = 0.0f;     //last tick's position X
        public static   float           lastPosZ                    = 0.0f;     //last tick's position Z

        public static   float           newPosX                     = 0.0f;     //this tick's position X
        public static   float           newPosZ                     = 0.0f;     //this tick's position Z

        public static   float           rotX                        = 0.0f;     //rotation X
        public static   float           rotY                        = 0.0f;     //rotation Y
        public static   float           rotZ                        = 0.0f;     //rotation Z

        public static   float           walkingXangle               = 0.0f;     //X-axis-angle on walking

        public static   bool            cheat_clipping              = false;    //cheat: no clipping

        public static   int             column                      = 0;        //column locating on

        public static   GraphicsPath    characterGraphicsPath       = null;     //the GraphicsPath for the Region
        public static   Region          characterRegion             = null;     //the character's Region
        public static   Region          collisionRegion             = null;

        public static void init()
        {
            posX            = Level.startPosX;
            posY            = Level.startPosY;
            posZ            = Level.startPosZ;

            rotX            = 0.0f;
            rotY            = Level.startRotY;
            rotZ            = 0.0f;

            walkingXangle   = 0.0f;

        } //endmethod

        public static void proceedToNewPosition()
        {
            //no proceeding if the position wasn't changed!
            if ( posX != newPosX || posZ != newPosZ )
            {
                float   stepX   = ( newPosX - posX ) / CHARACTER_COLLISION_STEPS;
                float   stepZ   = ( newPosZ - posZ ) / CHARACTER_COLLISION_STEPS;

                //change the character's position to the target-point in X steps
                for ( int currentStep = 0; currentStep < CHARACTER_COLLISION_STEPS; ++currentStep )
                {
                    //assign last position
                    lastPosX    = posX;
                    lastPosZ    = posZ;

                    //do one step
                    posX        += stepX;
                    posZ        += stepZ;

                    //check collisions on the current position
                    if ( !cheat_clipping )
                    {
                        checkCollisions();
                    } //endif
                } //endfor
            } //endif
        } //endmethod

        public static void checkCollisions()
        {
            bool resetX = false;
            bool resetZ = false;

            if ( isColliding( posX, posZ ) )
            {
                if ( isColliding( lastPosX, posZ ) )
                {
                    resetZ = true;
                } //endif

                if ( isColliding( posX, lastPosZ ) )
                {
                    resetX = true;
                } //endif

                //reset X or Z if desired!
                if ( resetX )
                {
                    posX    = lastPosX;
                } //endif

                if ( resetZ )
                {
                    posZ    = lastPosZ;
                } //endif
            } //endif
        } //endmethod

        public static bool isColliding( float checkX, float checkZ )
        {
            //update character's region
            characterGraphicsPath = new GraphicsPath();
            characterGraphicsPath.AddEllipse( new RectangleF( 1000 * ( checkX - CHARACTER_RADIUS ), 1000 * ( checkZ - CHARACTER_RADIUS ), 2000 * CHARACTER_RADIUS, 2000 * CHARACTER_RADIUS ) );
            characterRegion = new Region( characterGraphicsPath );

            //browse all meshCollections
            foreach ( MeshCollection meshCollection in Level.meshCollections )
            {
                foreach ( Mesh mesh in meshCollection.meshes )
                {
                    //only proceed if..
                    if
                    (
                        //character's on the same y
                            posY == mesh.y
                        //the current mesh has an inside-region
                        &&  mesh.insideRegion != null
                    )
                    {
                        collisionRegion = new Region( characterRegion.GetRegionData() );
                        collisionRegion.Intersect( mesh.insideRegion );
                        if ( !collisionRegion.IsEmpty( Shooter3DForm.aGraphicsObject ) )
                        {
                            return true;
                        } //endif
                    } //endif
                } //endforeach
            } //endforeach

            return false;

        } //endmethod

        public static void checkSpecialRegions()
        {
            //update character's region
            characterGraphicsPath = new GraphicsPath();
            characterGraphicsPath.AddEllipse( new RectangleF( 1000 * ( posX - CHARACTER_RADIUS ), 1000 * ( posZ - CHARACTER_RADIUS ), 2000 * CHARACTER_RADIUS, 2000 * CHARACTER_RADIUS ) );
            characterRegion = new Region( characterGraphicsPath );

            //browse all meshCollections
            foreach ( MeshCollection meshCollection in Level.meshCollections )
            {
                //browse all meshes
                foreach ( Mesh mesh in meshCollection.meshes )
                {
                    //check for a special-region
                    if ( mesh.specialRegion != null )
                    {
                        /*
                        collisionRegion = new Region( characterRegion.GetRegionData() );
                        collisionRegion.Intersect( mesh.specialRegion );
                        if ( !collisionRegion.IsEmpty( Shooter3DForm.aGraphicsObject ) )
                        */
                        collisionRegion = new Region( characterRegion.GetRegionData() );
                        collisionRegion.Intersect( mesh.specialRegion );
                        if ( mesh.specialRegion.IsVisible( new PointF( 1000 * posX, 1000 * posZ ) ) )
                        {
                            //check the feature of the special-region!
                            switch ( mesh.specialFeature )
                            {
                                case Mesh.SPECIAL_FEATURE_ASCENDING_FRONT:
                                {
                                    if ( Character.posZ - mesh.z < 0.05 )
                                    {
                                        Character.posY = mesh.y;
                                    }
                                    else if ( Character.posZ - mesh.z > mesh.height - 0.05 )
                                    {
                                        Character.posY = mesh.y + mesh.depth;
                                    }
                                    else
                                    {
                                        Character.posY = mesh.y + ( Character.posZ - mesh.z ) * mesh.depth / mesh.height;
                                    } //endif
                                    break;
                                } //endcase

                                case Mesh.SPECIAL_FEATURE_DESCENDING_FRONT:
                                {
                                    if ( Character.posZ - mesh.z < 0.05 )
                                    {
                                        Character.posY = mesh.y;
                                    }
                                    else if ( Character.posZ - mesh.z > mesh.height - 0.05 )
                                    {
                                        Character.posY = mesh.y - mesh.depth;
                                    }
                                    else
                                    {
                                        Character.posY = mesh.y - ( Character.posZ - mesh.z ) * mesh.depth / mesh.height;
                                    } //endif
                                    break;
                                } //endcase

                            } //endswitch
                        } //endif
                    } //endif
                } //endforeach
            } //endforeach
        } //endmethod
    } //endclass
} //endnamespace

/*
 *  $Log: Character.cs,v $
 *  Revision 1.15  2006/11/17 06:46:14  jenetic.bytemare
 *  safe
 *
 *  Revision 1.6  2006/10/31 01:27:26  Mr. jenetic.bytemare
 *  new meshes
 *
 *  Revision 1.5  2006/10/31 00:03:18  Mr. jenetic.bytemare
 *  completed descending walls - fixed a bug
 *
 *  Revision 1.4  2006/10/10 12:23:08  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.3  2006/10/10 11:28:33  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.14  2006/10/09 17:26:22  jenetic.bytemare
 *  elevated floors completed
 *
 *  Revision 1.13  2006/10/08 20:50:27  jenetic.bytemare
 *  completed multi-object 3ds implementation
 *
 *  Revision 1.12  2006/10/06 18:19:14  jenetic.bytemare
 *  completed unmasked faces
 *  repackaged classes
 *
 *  Revision 1.11  2006/10/06 15:50:30  jenetic.bytemare
 *  blending-problems in progress ..
 *
 *  Revision 1.10  2006/10/05 19:05:27  jenetic.bytemare
 *  rearranged packages
 *  completed box-mesh
 *
 *  Revision 1.9  2006/10/04 22:13:29  jenetic.bytemare
 *  completed collision-system
 *
 *  Revision 1.8  2006/10/04 21:10:05  jenetic.bytemare
 *  collisions in progress ..
 *
 *  Revision 1.7  2006/10/04 12:23:56  jenetic.bytemare
 *  new wall-system completed
 *  pruned 2d-array-structure!
 *
 *  Revision 1.6  2006/10/03 20:29:38  jenetic.bytemare
 *  completed cell-system
 *  implemented cell-templates
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
 *  Revision 1.2  2006/10/01 15:45:08  jenetic.bytemare
 *  3dsmax import in progress
 *
 *  Revision 1.1  2006/10/01 10:07:22  jenetic.bytemare
 *  pruned present code
 *  created class character
 *
 *
 */

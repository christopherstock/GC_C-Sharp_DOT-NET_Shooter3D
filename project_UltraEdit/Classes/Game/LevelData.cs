/*  $Id: LevelData.cs,v 1.17 2006/11/17 06:46:14 jenetic.bytemare Exp $
 *  ==================================================================================
 *  Holds all level-data.
 */

using System;
using System.Windows.Forms;
using Classes.Engine3D;
using Classes.Engine3D.MeshCollection;
using Classes.Engine3D.WallFaces;
using Classes.Engine3D.SolidMeshes;
using Classes.Engine3D.MaskedMeshes;

namespace Classes.Game
{
    public class LevelData
    {
        public  static  object[][]  levelData           = new object[][]
        {
            //                  LEVEL_WIDTH,    LEVEL_HEIGHT,   LEVEL_START_POS_X,  LEVEL_START_POS_Y,  LEVEL_START_POS_Z,  LEVEL_START_ROT_Y,  LEVEL_BG,
            /*  LEVEL_1     */
            new object[]
            {
                new float[] {   30.0f,          25.0f,          3.5f,               0.0f,               2.0f,               180.0f,             Texture.TEXTURE_BG_DESERT_CANYON,  },

                new MeshCollection[]
                {
                    new MeshCollection
                    (
                        new Mesh[]
                        {
                            //ground
                            new FloorMesh(     0.0f,   0.0f,   0.0f,   30.0f,  9.0f,  Texture.TEXTURE_SAND_1,     Texture.TILING_DEFAULT,     Texture.TILING_DEFAULT ),
                            new CeilingMesh(   0.0f,   1.0f,   0.0f,   30.0f,  9.0f,  Texture.TEXTURE_TEST,       Texture.TILING_DEFAULT,     Texture.TILING_DEFAULT )
                        }
                    ),
                    new MeshCollection
                    (
                        new Mesh[]
                        {
                            //huts
                            new House(      8.0f,   0.0f,   7.0f,   1.5f,   1.5f,   0.5f,   0.1f,   0.5f,   Texture.TEXTURE_BRICKS_4,       Texture.TILING_DEFAULT,     Texture.TILING_DEFAULT, Texture.TEXTURE_BRICKS_4, Texture.TILING_DEFAULT, Texture.TILING_DEFAULT, Texture.TEXTURE_WOOD_3, Texture.TILING_DEFAULT, Texture.TILING_DEFAULT, Texture.TEXTURE_WOOD_3, Texture.TILING_DEFAULT, Texture.TILING_DEFAULT  )
                        }
                    ),

                    new MeshCollection
                    (
                        new Mesh[]
                        {
                            //huts
                            new Barrel(      3.0f,   0.0f,   3.0f  ),
                        }
                    ),

                    new MeshCollection
                    (
                        new Mesh[]
                        {
                            //frontWallMesh
                            new FrontWallMesh(      4.0f,   0.0f,   0.0f,   1.5f,   0.5f,   Texture.TEXTURE_TEST, Texture.TILING_DEFAULT, Texture.TILING_DEFAULT ),

                            //rearWallMesh
                            new RearWallMesh(      4.0f,   0.0f,   0.5f,   1.5f,   0.5f,   Texture.TEXTURE_TEST, Texture.TILING_DEFAULT, Texture.TILING_DEFAULT ),

                            //rearWallMesh
                            new LeftWallMesh(      8.0f,   0.0f,   1.5f,   1.5f,   0.5f,   Texture.TEXTURE_TEST, Texture.TILING_DEFAULT, Texture.TILING_DEFAULT ),

                            //rearWallMesh
                            new RightWallMesh(      8.1f,   0.0f,   1.5f,   1.5f,   0.5f,   Texture.TEXTURE_TEST, Texture.TILING_DEFAULT, Texture.TILING_DEFAULT ),
                        }
                    ),

                    //stairs!
                    new MeshCollection
                    (
                        new Mesh[]
                        {
                            new AscendingFront(      4.0f,   0.0f,   1.5f,   0.5f,  0.5f, 0.5f,  Texture.TEXTURE_STAIRS_1,     Texture.TILING_DEFAULT,     Texture.TILING_DEFAULT      ),
                        }
                    ),
                    new MeshCollection
                    (
                        new Mesh[]
                        {
                            new DescendingFront(      4.0f,   0.0f,   9.0f,   0.5f,  0.5f, 0.5f,  Texture.TEXTURE_TEST,     Texture.TILING_DEFAULT,     Texture.TILING_DEFAULT      ),
                        }
                    ),


/*
                    //houses
                    new House(  2.0f,   0.0f,   2.0f,   2.0f,   3.0f,   0.5f,   0.1f,   0.5f,   Texture.TEXTURE_BRICKS_2,       Texture.TILING_DEFAULT,     Texture.TILING_DEFAULT, Texture.TEXTURE_WOOD_2, Texture.TILING_DEFAULT, Texture.TILING_DEFAULT  ),
                    new House(  6.0f,   0.0f,   5.0f,   2.0f,   3.0f,   0.5f,   0.1f,   0.5f,   Texture.TEXTURE_BRICKS_1,       Texture.TILING_DEFAULT,     Texture.TILING_DEFAULT, Texture.TEXTURE_WOOD_2, Texture.TILING_DEFAULT, Texture.TILING_DEFAULT  ),
                    new House(  3.0f,   0.0f,   9.5f,   5.5f,   4.0f,   0.5f,   0.1f,   0.5f,   Texture.TEXTURE_BRICKS_3,       Texture.TILING_DEFAULT,     Texture.TILING_DEFAULT, Texture.TEXTURE_WOOD_2, Texture.TILING_DEFAULT, Texture.TILING_DEFAULT  ),
                    new Box(    3.5f,   0.0f,   1.75f,  0.2f,   0.2f,   0.2f,                   Texture.TEXTURE_CRATE_1,        Texture.TILING_1,           Texture.TILING_1                                                                                ),

                    //car
                    new Car(    0.5f,   2.5f,   5.0f    ),
                    //new Tree(   1.0f,   1.0f,   1.0f    ),
*/
                    //masked meshes
                    new MeshCollection
                    (
                        new Mesh[]
                        {
                            new Bush(   2.5f,   0.0f,   1.8f,   0.2f,   0.2f,   0.2f,   0.1f,           Texture.TEXTURE_BUSH_MASK_1,    Texture.TEXTURE_BUSH_1,     Texture.TILING_1,       Texture.TILING_1 ),
                        }
                    ),
                },
            },
        }; //endarray
    } //endclass
} //endnamespace

/*
 *  $Log: LevelData.cs,v $
 *  Revision 1.17  2006/11/17 06:46:14  jenetic.bytemare
 *  safe
 *
 *  Revision 1.11  2006/10/16 14:18:56  Mr. jenetic.bytemare
 *  advanced 3dsmax-importer
 *
 *  Revision 1.10  2006/10/12 14:12:08  Mr. jenetic.bytemare
 *  implemented directX sound-system
 *  levelEditor in progress
 *
 *  Revision 1.9  2006/10/31 01:27:26  Mr. jenetic.bytemare
 *  new meshes
 *
 *  Revision 1.8  2006/10/31 00:03:18  Mr. jenetic.bytemare
 *  completed descending walls - fixed a bug
 *
 *  Revision 1.7  2006/10/10 18:25:00  Mr. jenetic.bytemare
 *  completed bg
 *
 *  Revision 1.6  2006/10/10 18:08:31  Mr. jenetic.bytemare
 *  completed bg
 *
 *  Revision 1.5  2006/10/10 13:56:12  Mr. jenetic.bytemare
 *  bg implementation
 *
 *  Revision 1.4  2006/10/10 12:23:08  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.3  2006/10/10 11:28:33  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.16  2006/10/09 17:26:22  jenetic.bytemare
 *  elevated floors completed
 *
 *  Revision 1.15  2006/10/08 20:50:27  jenetic.bytemare
 *  completed multi-object 3ds implementation
 *
 *  Revision 1.14  2006/10/06 20:27:51  jenetic.bytemare
 *  completed 3dsmax-importer
 *
 *  Revision 1.13  2006/10/06 18:22:41  jenetic.bytemare
 *  repackaged classes
 *
 *  Revision 1.12  2006/10/06 18:19:14  jenetic.bytemare
 *  completed unmasked faces
 *  repackaged classes
 *
 *  Revision 1.11  2006/10/06 15:50:30  jenetic.bytemare
 *  blending-problems in progress ..
 *
 *  Revision 1.10  2006/10/06 11:41:50  jenetic.bytemare
 *  outsourced hud
 *  new class for masked quad-faces
 *
 *  Revision 1.9  2006/10/05 19:05:28  jenetic.bytemare
 *  rearranged packages
 *  completed box-mesh
 *
 *  Revision 1.8  2006/10/04 21:10:05  jenetic.bytemare
 *  collisions in progress ..
 *
 *  Revision 1.7  2006/10/04 14:23:07  jenetic.bytemare
 *  house-object completed
 *
 *  Revision 1.6  2006/10/04 12:23:56  jenetic.bytemare
 *  new wall-system completed
 *  pruned 2d-array-structure!
 *
 *  Revision 1.5  2006/10/03 20:29:38  jenetic.bytemare
 *  completed cell-system
 *  implemented cell-templates
 *
 *  Revision 1.4  2006/10/03 17:04:24  jenetic.bytemare
 *  completed floor, left and right wall
 *
 *  Revision 1.3  2006/10/03 15:14:36  jenetic.bytemare
 *  tyding all classes
 *
 *  Revision 1.2  2006/10/03 13:42:19  jenetic.bytemare
 *  completed floor-texturing
 *
 *  Revision 1.1  2006/10/02 11:23:41  jenetic.bytemare
 *  completed 3dsmax-importer.
 *  rearranged packages.
 *
 */

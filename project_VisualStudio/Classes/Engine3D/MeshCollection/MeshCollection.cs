/*  $Id: MeshCollection.cs,v 1.1 2006/11/17 06:46:14 jenetic.bytemare Exp $
 *  =================================================================================
 *  A mesh-collection consists of meshes.
 */

using System;
using System.Drawing;
using System.IO;
using CsGL.OpenGL;
using Classes.Game;
using Classes.Engine3D;

namespace Classes.Engine3D.MeshCollection
{
    public class MeshCollection
    {
        public  Mesh[]      meshes                                      = null;

        public MeshCollection( Mesh[] initMeshes )
        {
            meshes = initMeshes;
        } //endconstruct

        public void draw()
        {
            //draw all meshes
            foreach ( Mesh mesh in meshes )
            {
                mesh.draw();
            } //endforeach
        } //endmethod
    } //endclass
} //endnamespace

/*
 *  $Log: MeshCollection.cs,v $
 *  Revision 1.1  2006/11/17 06:46:14  jenetic.bytemare
 *  safe
 *
 *  Revision 1.1  2006/10/31 00:03:14  Mr. jenetic.bytemare
 *  completed descending walls - fixed a bug
 *
 *  Revision 1.4  2006/10/10 12:23:07  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.3  2006/10/10 11:28:30  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.8  2006/10/09 17:26:20  jenetic.bytemare
 *  elevated floors completed
 *
 *  Revision 1.7  2006/10/06 20:27:49  jenetic.bytemare
 *  completed 3dsmax-importer
 *
 *  Revision 1.6  2006/10/06 18:27:13  jenetic.bytemare
 *  pruned obsolete classes
 *
 *  Revision 1.5  2006/10/06 18:22:41  jenetic.bytemare
 *  repackaged classes
 *
 *  Revision 1.4  2006/10/06 15:50:30  jenetic.bytemare
 *  blending-problems in progress ..
 *
 *  Revision 1.2  2006/10/06 11:41:50  jenetic.bytemare
 *  outsourced hud
 *  new class for masked quad-faces
 *
 *  Revision 1.1  2006/10/05 19:05:27  jenetic.bytemare
 *  rearranged packages
 *  completed box-mesh
 *
 *  Revision 1.1  2006/10/04 14:23:07  jenetic.bytemare
 *  house-object completed
 *
 *
 */

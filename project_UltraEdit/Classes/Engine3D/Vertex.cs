/*  $Id: Vertex.cs,v 1.4 2006/11/17 06:46:13 jenetic.bytemare Exp $
 *  =================================================================================
 *  Represents a vector.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using CsGL.OpenGL;

namespace Classes.Engine3D
{
    public class Vertex
    {
        public  float           x               = 0;    //location x
        public  float           y               = 0;    //location y
        public  float           z               = 0;    //location z
        public  float           u               = 0;    //texture  x
        public  float           v               = 0;    //texture  y

        public  Vertex( float initX, float initY, float initZ, float initU, float initV )
        {
            x = initX;
            y = initY;
            z = initZ;
            u = initU;
            v = initV;

        } //endconstruct
    } //endclass
} //endnamespace

/*
 *  $Log: Vertex.cs,v $
 *  Revision 1.4  2006/11/17 06:46:13  jenetic.bytemare
 *  safe
 *
 *  Revision 1.3  2006/10/10 11:28:31  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.3  2006/10/03 17:04:24  jenetic.bytemare
 *  completed floor, left and right wall
 *
 *  Revision 1.2  2006/10/02 21:54:59  jenetic.bytemare
 *  implemented point-colliding
 *  region-colliding in progress
 *
 *  Revision 1.1  2006/10/02 11:23:41  jenetic.bytemare
 *  completed 3dsmax-importer.
 *  rearranged packages.
 */

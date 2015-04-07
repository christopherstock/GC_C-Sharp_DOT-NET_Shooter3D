/*  $Id: Mesh.cs,v 1.1 2006/11/17 06:47:40 jenetic.bytemare Exp $
 *  =================================================================================
 *  The 3dsmax-loader.
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Classes
{
    public class Mesh
    {
        public  const   int     MESH_FRONT_WALL             = 0;
        public  const   int     MESH_REAR_WALL              = 1;
        public  const   int     MESH_LEFT_WALL              = 2;
        public  const   int     MESH_RIGHT_WALL             = 3;
        public  const   int     MESH_FLOOR                  = 4;
        public  const   int     MESH_CEILING                = 5;

        public  const   int     TEXTURE_STONES_1            = 0;

        public  const   int     TEXTURE_TILING_DEFAULT      = 0;

        public          int     type                        = 0;
        public          float   x                           = 1;
        public          float   y                           = 2;
        public          float   z                           = 3;
        public          float   width                       = 4;
        public          float   height                      = 5;
        public          float   depth                       = 6;
        public          int     textureID                   = 7;
        public          float   textureX                    = 8;
        public          float   textureY                    = 9;

        public  static  Mesh[]  meshes                      = new Mesh[]
        {
            new Mesh( MESH_FRONT_WALL, 1.0f, 0.0f, 1.0f, 1.0f, 0.0f, 1.0f, TEXTURE_STONES_1, TEXTURE_TILING_DEFAULT, TEXTURE_TILING_DEFAULT ),
        };

        public Mesh( int initType, float initX, float initY, float initZ, float initWidth, float initHeight, float initDepth, int initTextureID, int initTextureX, int initTextureY )
        {
            type        = initType;
            x           = initX;
            y           = initY;
            z           = initZ;
            width       = initWidth;
            height      = initHeight;
            depth       = initDepth;
            textureID   = initTextureID;
            textureX    = initTextureX;
            textureY    = initTextureY;

        } //endmethod

        public void draw( Graphics g )
        {
            switch ( type )
            {
                case MESH_FRONT_WALL:
                {
                    g.FillRectangle( LevelEditorForm.blackBrush,    new RectangleF( LevelEditorPanel.OFFSET_PADDING_LEFT + x * 10, LevelEditorPanel.OFFSET_PADDING_TOP + ( z * 10 ) - 1,  width * 10, 1 ) );
                    g.FillRectangle( LevelEditorForm.redBrush,      new RectangleF( LevelEditorPanel.OFFSET_PADDING_LEFT + x * 10, LevelEditorPanel.OFFSET_PADDING_TOP + ( z * 10 ),      width * 10, 1 ) );
                    break;
                } //endcase
            } //endswitch
        } //endmethod

    } //endclass
} //endnamespace


/*
 *  $Log: Mesh.cs,v $
 *  Revision 1.1  2006/11/17 06:47:40  jenetic.bytemare
 *  safe
 *
 *  Revision 1.3  2006/10/16 11:35:13  Mr. jenetic.bytemare
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
    
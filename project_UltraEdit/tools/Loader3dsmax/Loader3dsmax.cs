/*  $Id: Loader3dsmax.cs,v 1.5 2006/11/17 06:46:15 jenetic.bytemare Exp $
 *  =================================================================================
 *  The 3dsmax-loader.
 */

using System;
using System.Drawing;
using System.IO;

namespace Loader3dsmax
{
    public class Loader3dsmax
    {
        public  static  Face[]          faces           = null;
        public  static  Vertex[]        vertices        = null;
        public  static  TextureVertex[] textureVertices = null;

        public static void Main()
        {
            Console.WriteLine( "Reading 3dsmax-file.." );

            StreamReader    inStream            = null;
            StreamWriter    outStream           = null;
            int             currentTexture      = 0;
            string          line                = "";
            string[]        words               = null;


            //open the AsciiSceneImport-file and the output-file
            try
            {
                inStream    = new StreamReader( "in.ase", System.Text.Encoding.ASCII );
                outStream   = new StreamWriter( "out.txt", false );
            }
            catch( Exception)
            {
                Console.WriteLine( "file 'in.ase' not found in the current directory!" );
                return;
            } //endcatch

            //browse all meshes
            do
            {
                //next texture!
                ++currentTexture;

                //read number of vertices
                line        = fetchLine( inStream, "*MESH_NUMVERTEX" );

                //quit app if no more meshes are to come!
                if ( line == null )
                {
                    //close the streams
                    inStream.Close();
                    outStream.Close();
                    Console.WriteLine("done");
                    return;
                } //endif

                Console.WriteLine( "\nExport mesh #{0}", currentTexture );

                words       = splitLine( line );
                vertices    = new Vertex[ int.Parse( words[ words.Length - 1 ] ) ];

                Console.WriteLine( "{0} vertices to read.", vertices.Length );

                //read number of faces
                line        = fetchLine( inStream, "*MESH_NUMFACES" );
                words       = splitLine( line );
                faces       = new Face[ int.Parse( words[ words.Length - 1 ] ) ];

                Console.WriteLine( "{0} faces to read.", faces.Length );

                //read all vertices
                line        = fetchLine( inStream, "*MESH_VERTEX_LIST" );
                for ( int currentVertex = 0; currentVertex < vertices.Length; ++currentVertex )
                {
                    //read next vertex
                    line = inStream.ReadLine();
                    words = splitLine( line );

                    //assign all vertices
                    vertices[ currentVertex ] = new Vertex
                    (
                        float.Parse( words[ words.Length - 3 ] ) / 1000,
                        float.Parse( words[ words.Length - 2 ] ) / 1000,
                        float.Parse( words[ words.Length - 1 ] ) / 1000
                    );
                } //endfor

                Console.WriteLine( "All vertices are read." );

                //read all faces
                line        = fetchLine( inStream, "*MESH_FACE_LIST" );
                for ( int currentFace = 0; currentFace < faces.Length; ++currentFace )
                {
                    //read next face
                    line  = inStream.ReadLine();
                    words = splitLine( line );

                    //assign all faces
                    faces[ currentFace ] = new Face
                    (
                        vertices[ int.Parse( words[ 3 ] ) ],
                        vertices[ int.Parse( words[ 5 ] ) ],
                        vertices[ int.Parse( words[ 7 ] ) ]
                    );

                    Console.WriteLine( "{0} vertex face", words[3] );
                    Console.WriteLine( "{0} vertex face", words[5] );
                    Console.WriteLine( "{0} vertex face", words[7] );

                } //endfor

                Console.WriteLine( "All faces are read." );

                //read all texture-vertices
                line            = fetchLine( inStream, "*MESH_NUMTVERTEX" );
                words           = splitLine( line );
                textureVertices = new TextureVertex[ int.Parse( words[ words.Length - 1 ] ) ];

                line            = fetchLine( inStream, "*MESH_TVERTLIST" );
                for ( int currentTextureVertex = 0; currentTextureVertex < textureVertices.Length; ++currentTextureVertex )
                {
                    //read next texture-vertex
                    line = inStream.ReadLine();
                    words = splitLine( line );

                    //assign all texture-vertices
                    textureVertices[ currentTextureVertex ] = new TextureVertex
                    (
                        float.Parse( words[ words.Length - 3 ] ),
                        float.Parse( words[ words.Length - 2 ] )
                    );

                } //endfor

                Console.WriteLine( "All texture-vertices are read." );

                //assign all texture-vertices to the faces
                line = fetchLine( inStream, "*MESH_TFACELIST" );

                for ( int currentTextureFace = 0; currentTextureFace < faces.Length; ++currentTextureFace )
                {
                    //read next texture-face
                    line = inStream.ReadLine();
                    words = splitLine( line );

                    //assign all texture-faces
                    faces[ currentTextureFace ].vertex1.u = textureVertices[ int.Parse( words[ words.Length - 3 ] ) ].u;
                    faces[ currentTextureFace ].vertex1.v = textureVertices[ int.Parse( words[ words.Length - 3 ] ) ].v;
                    faces[ currentTextureFace ].vertex2.u = textureVertices[ int.Parse( words[ words.Length - 2 ] ) ].u;
                    faces[ currentTextureFace ].vertex2.v = textureVertices[ int.Parse( words[ words.Length - 2 ] ) ].v;
                    faces[ currentTextureFace ].vertex3.u = textureVertices[ int.Parse( words[ words.Length - 1 ] ) ].u;
                    faces[ currentTextureFace ].vertex3.v = textureVertices[ int.Parse( words[ words.Length - 1 ] ) ].v;

                } //endfor

                Console.WriteLine( "All texture-vertices are assigned to the faces." );

                //browse and export all faces
                foreach( Face face in faces )
                {
                    outStream.WriteLine( "new SolidFace\n(\n    Texture.TEXTURE_WOOD_" + currentTexture + " ,\n    new float[] { 1.0f, 1.0f, 0.0f },\n    new Vertex[]\n    {" );

                    outStream.WriteLine( "        new Vertex ( posX + {0}f, posY + {1}f, posZ + {2}f, {3}f, {4}f ),", ( face.vertex1.x / 10 ).ToString().Replace(',', '.'), ( face.vertex1.y / 10 ).ToString().Replace(',', '.'), ( face.vertex1.z / 10 ).ToString().Replace(',', '.'), ( face.vertex1.u / 10 ).ToString().Replace(',', '.'), ( face.vertex1.v / 10 ).ToString().Replace(',', '.') );
                    outStream.WriteLine( "        new Vertex ( posX + {0}f, posY + {1}f, posZ + {2}f, {3}f, {4}f ),", ( face.vertex2.x / 10 ).ToString().Replace(',', '.'), ( face.vertex2.y / 10 ).ToString().Replace(',', '.'), ( face.vertex2.z / 10 ).ToString().Replace(',', '.'), ( face.vertex2.u / 10 ).ToString().Replace(',', '.'), ( face.vertex2.v / 10 ).ToString().Replace(',', '.') );
                    outStream.WriteLine( "        new Vertex ( posX + {0}f, posY + {1}f, posZ + {2}f, {3}f, {4}f ),", ( face.vertex3.x / 10 ).ToString().Replace(',', '.'), ( face.vertex3.y / 10 ).ToString().Replace(',', '.'), ( face.vertex3.z / 10 ).ToString().Replace(',', '.'), ( face.vertex3.u / 10 ).ToString().Replace(',', '.'), ( face.vertex3.v / 10 ).ToString().Replace(',', '.') );
                    outStream.WriteLine( "    }\n)," );

                } //endforeach
            }
            while( true );

        } //endmethod

        private static string[] splitLine( string lineToSplit )
        {
            string[] wordsToReturn = null;

            //change all tabs and spaces to semicolons
            lineToSplit = lineToSplit.Replace( '\t',  ';' );
            lineToSplit = lineToSplit.Replace( ' ',   ';' );

            //split on semicolons
            wordsToReturn = lineToSplit.Split( ';' );

            lineToSplit = "";

            //prune empty elements
            for ( int currentWord = 0; currentWord < wordsToReturn.Length; ++currentWord )
            {
                if ( wordsToReturn[ currentWord ] != "" )
                {
                    lineToSplit += wordsToReturn[ currentWord ];
                    if ( currentWord < wordsToReturn.Length - 1 )
                    {
                        lineToSplit += ";";
                    } //endif
                } //endif
            } //endfor

            wordsToReturn = lineToSplit.Split( ';' );

            return wordsToReturn;

        } //endmethod

        private static string fetchLine( StreamReader stream, string needle )
        {
            string haystack;

            do
            {
                haystack = stream.ReadLine();
            }
            while
            (
                //break if needle was found
                    haystack != null
                &&  haystack.IndexOf( needle ) == -1
            );

            return haystack;

        } //endmethod
    } //endclass

    public class Vertex
    {
        public float    x   = 0;
        public float    y   = 0;
        public float    z   = 0;
        public float    u   = 0;
        public float    v   = 0;

        public Vertex( float initX, float initY, float initZ )
        {
            x = initX;
            y = initY;
            z = initZ;

        } //endconstruct
    } //endclass

    public class TextureVertex
    {
        public float    u   = 0;
        public float    v   = 0;

        public TextureVertex( float initU, float initV )
        {
            u = initU;
            v = initV;

        } //endconstruct
    } //endclass

    public class Face
    {
        public  Vertex  vertex1 = null;
        public  Vertex  vertex2 = null;
        public  Vertex  vertex3 = null;

        public Face( Vertex initVertex1, Vertex initVertex2, Vertex initVertex3 )
        {
            vertex1 = initVertex1;
            vertex2 = initVertex2;
            vertex3 = initVertex3;

        } //endmethod
    } //endclass
} //endnamespace

/*
 *  $Log: Loader3dsmax.cs,v $
 *  Revision 1.5  2006/11/17 06:46:15  jenetic.bytemare
 *  safe
 *
 *  Revision 1.4  2006/10/16 14:18:57  Mr. jenetic.bytemare
 *  advanced 3dsmax-importer
 *
 *  Revision 1.3  2006/10/10 11:28:33  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.4  2006/10/09 17:26:23  jenetic.bytemare
 *  elevated floors completed
 *
 *  Revision 1.3  2006/10/08 20:50:28  jenetic.bytemare
 *  completed multi-object 3ds implementation
 *
 *  Revision 1.2  2006/10/06 20:27:52  jenetic.bytemare
 *  completed 3dsmax-importer
 *
 *  Revision 1.1  2006/10/05 19:05:30  jenetic.bytemare
 *  rearranged packages
 *  completed box-mesh
 *
 *  Revision 1.5  2006/10/04 21:10:05  jenetic.bytemare
 *  collisions in progress ..
 *
 *  Revision 1.4  2006/10/03 17:04:24  jenetic.bytemare
 *  completed floor, left and right wall
 *
 *  Revision 1.3  2006/10/03 13:42:20  jenetic.bytemare
 *  completed floor-texturing
 *
 *  Revision 1.2  2006/10/02 18:40:23  jenetic.bytemare
 *  2d-array and collisions completed
 *
 *  Revision 1.1  2006/10/02 11:23:41  jenetic.bytemare
 *  completed 3dsmax-importer.
 *  rearranged packages.
 *
 *  Revision 1.4  2006/10/02 10:23:34  jenetic.bytemare
 *  streaming 3dsmax texture-vertices and texture-faces
 *
 *  Revision 1.3  2006/10/01 21:01:04  jenetic.bytemare
 *  completed 3dsmax-importer [textures are to come!]
 *
 *  Revision 1.2  2006/10/01 20:16:54  jenetic.bytemare
 *  restructured face- and vertex-class
 *
 *  Revision 1.1  2006/10/01 19:01:44  jenetic.bytemare
 *  loader for importing 3dsmax-meshes in progress
 *  implemented strafing
 *  implemented frames-per-second debugging
 *
 *
 */

/*
        private void drawTestZeuch()
        {
            //clear GL
            GL.glClear( GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT );

            //blue square
            GL.glLoadIdentity();                            // Reset The Current Modelview Matrix
            GL.glTranslatef(2.0f,0.0f,-6.0f);                // From Right Point Move 3 Units Right
            GL.glColor3f(0.5f,0.5f,1.0f);                    // Set The Color To Blue One Time Only
            GL.glBegin(GL.GL_QUADS);                        // Start Drawing Quads
                GL.glVertex3f(-1.0f, 1.0f, 0.0f);            // Left And Up 1 Unit (Top Left)
                GL.glVertex3f( 1.0f, 1.0f, 0.0f);            // Right And Up 1 Unit (Top Right)
                GL.glVertex3f( 1.0f,-1.0f, 0.0f);            // Right And Down One Unit (Bottom Right)
                GL.glVertex3f(-1.0f,-1.0f, 0.0f);            // Left And Down One Unit (Bottom Left)
            GL.glEnd();                                        // Done Drawing A Quad

            //set color
            GL.glColor3f( 0.0f, 0.0f, 0.0f);
            GL.glColor3fv( new float[] { 0.0f, 0.0f, 0.0f } );

            //3D-Room
            GL.glLoadIdentity();                            // Reset The Current Modelview Matrix

            float x_m;
            float y_m;
            float z_m;
            float u_m;
            float v_m;

            //normalize GL
            GL.glNormal3f( 0.0f, 0.0f, 1.0f );                              //no effect??

            //rotate GL
            GL.glRotatef( Character.rotZ,           0.0f, 0.0f, 1.0f );     //rotate x-axis
            GL.glRotatef( Character.rotX,           1.0f, 0.0f, 0.0f );     //rotate y-axis
            GL.glRotatef( 360.0f - Character.rotY,  0.0f, 1.0f, 0.0f );     //rotate z-axis

            //translate GL
            GL.glTranslatef( -Character.posX, -Character.posY, -Character.posZ );

            //set normal colors for all textures to come
            GL.glColor3f(1.0f,1.0f,1.0f);

            //browse all triangles
            for ( int i = 0; i < mesh1.tripleFaces.Length; i++ )
            {
                //process each triangle
                GL.glEnable(        GL.GL_TEXTURE_2D            );      // Enable Texture Mapping
                GL.glBindTexture(   GL.GL_TEXTURE_2D, texture[ currentTexture ] );

                GL.glBegin( GL.GL_TRIANGLES );

                //1st vertex
                x_m = mesh1.tripleFaces[i].vertex1.x;
                y_m = mesh1.tripleFaces[i].vertex1.y;
                z_m = mesh1.tripleFaces[i].vertex1.z;
                u_m = mesh1.tripleFaces[i].vertex1.textureVertex.u;
                v_m = mesh1.tripleFaces[i].vertex1.textureVertex.v;

                GL.glTexCoord2f( u_m, v_m );
                GL.glVertex3f( x_m, y_m, z_m );

                //2nd vertex
                x_m = mesh1.tripleFaces[i].vertex2.x;
                y_m = mesh1.tripleFaces[i].vertex2.y;
                z_m = mesh1.tripleFaces[i].vertex2.z;
                u_m = mesh1.tripleFaces[i].vertex2.textureVertex.u;
                v_m = mesh1.tripleFaces[i].vertex2.textureVertex.v;

                GL.glTexCoord2f( u_m, v_m );
                GL.glVertex3f( x_m, y_m, z_m );

                //3rd vertex
                x_m = mesh1.tripleFaces[i].vertex3.x;
                y_m = mesh1.tripleFaces[i].vertex3.y;
                z_m = mesh1.tripleFaces[i].vertex3.z;
                u_m = mesh1.tripleFaces[i].vertex3.textureVertex.u;
                v_m = mesh1.tripleFaces[i].vertex3.textureVertex.v;

                GL.glTexCoord2f( u_m, v_m );
                GL.glVertex3f( x_m, y_m, z_m );

                GL.glEnd();

            } //endfor

            //quad
            GL.glLoadIdentity();                                    //reset The Current Modelview Matrix
            GL.glDisable(       GL.GL_TEXTURE_2D        );          //unlink the texture!

            GL.glBegin(         GL.GL_QUADS             );
            GL.glNormal3f(      0.0f, 0.0f, 1.0f        );
           GL.glTexCoord2f(    0.0f, 0.0f              );
            GL.glColor3f( 0.9f, 0.0f, 0.0f );
            GL.glVertex3f(      -1.0f, -1.0f,  -5.0f    );
           GL.glTexCoord2f(    1.0f, 0.0f              );
            GL.glColor3f( 0.2f, 0.0f, 0.0f );
            GL.glVertex3f(      1.0f, -1.0f,  -5.0f     );
           GL.glTexCoord2f(    1.0f, 1.0f              );
            GL.glVertex3f(      1.0f,  1.0f,  -5.0f     );
           GL.glTexCoord2f(    0.0f, 1.0f              );
            GL.glVertex3f(      -1.0f,  1.0f,  -5.0f    );
            GL.glEnd();

            //colored triangle
            GL.glLoadIdentity();                            // reset the current modelview matrix
            //rotate and translate GL to player's position
            GL.glRotatef( Character.rotZ,           0.0f, 0.0f, 1.0f );     //rotate x-axis
            GL.glRotatef( Character.rotX,           1.0f, 0.0f, 0.0f );     //rotate y-axis
            GL.glRotatef( 360.0f - Character.rotY,  0.0f, 1.0f, 0.0f );     //rotate z-axis
            GL.glTranslatef( -Character.posX, -Character.posY, -Character.posZ );

            GL.glTranslatef(-1.5f,0.0f,-6.0f);                  // move 1.5 Units left and 6 Units into the screen
            GL.glRotatef( 5.0f ,0.0f,1.0f,0.0f);  // rotate the triangle on the Y-axis

            GL.glBegin(GL.GL_TRIANGLES);                        // Begin Drawing Faces
            GL.glColor3f(1.0f,0.0f,0.0f);                       // Set The Color To Red
            GL.glVertex3f( 0.0f, 1.0f, 0.0f);                   // Move Up One Unit From Center (Top Point)
            GL.glColor3f(0.0f,1.0f,0.0f);                       // Set The Color To Green
            GL.glVertex3f(-1.0f,-1.0f, 0.0f);                   // Left And Down One Unit (Bottom Left)
            GL.glColor3f(0.0f,0.0f,1.0f);                       // Set The Color To Blue
            GL.glVertex3f( 1.0f,-1.0f, 0.0f);                   // Right And Down One Unit (Bottom Right)
            GL.glEnd();                                         // Done Drawing A Face



            //3dsmax scene-import!
            //3D-Room
            GL.glLoadIdentity();                            // Reset The Current Modelview Matrix

            //normalize GL
            GL.glNormal3f( 0.0f, 0.0f, 1.0f );                              //no effect??

            //rotate GL
            GL.glRotatef( Character.rotZ,           0.0f, 0.0f, 1.0f );     //rotate x-axis
            GL.glRotatef( Character.rotX,           1.0f, 0.0f, 0.0f );     //rotate y-axis
            GL.glRotatef( 360.0f - Character.rotY,  0.0f, 1.0f, 0.0f );     //rotate z-axis

            //translate GL
            GL.glTranslatef( -Character.posX, -Character.posY, -Character.posZ );

            float chris     = 1.0f;
            float defjam    = 0.0f;
            float cori      = 1.0f;

            //browse all triangles
            for ( int i = 0; i < Loader3dsmax.tripleFaces.Length; i++ )
            {
                GL.glColor3f( chris, defjam, cori );

                //process each triangle
                GL.glBegin( GL.GL_TRIANGLES );

                //1st vertex
                x_m = Loader3dsmax.tripleFaces[i].vertex1.x;
                y_m = Loader3dsmax.tripleFaces[i].vertex1.y;
                z_m = Loader3dsmax.tripleFaces[i].vertex1.z;
                u_m = Loader3dsmax.tripleFaces[i].vertex1.textureVertex.u;
                v_m = Loader3dsmax.tripleFaces[i].vertex1.textureVertex.v;

                GL.glTexCoord2f( u_m, v_m );
                GL.glVertex3f( x_m, y_m, z_m );

                //2nd vertex
                x_m = Loader3dsmax.tripleFaces[i].vertex2.x;
                y_m = Loader3dsmax.tripleFaces[i].vertex2.y;
                z_m = Loader3dsmax.tripleFaces[i].vertex2.z;
                u_m = Loader3dsmax.tripleFaces[i].vertex2.textureVertex.u;
                v_m = Loader3dsmax.tripleFaces[i].vertex2.textureVertex.v;

                GL.glTexCoord2f( u_m, v_m );
                GL.glVertex3f( x_m, y_m, z_m );

                //3rd vertex
                x_m = Loader3dsmax.tripleFaces[i].vertex3.x;
                y_m = Loader3dsmax.tripleFaces[i].vertex3.y;
                z_m = Loader3dsmax.tripleFaces[i].vertex3.z;
                u_m = Loader3dsmax.tripleFaces[i].vertex3.textureVertex.u;
                v_m = Loader3dsmax.tripleFaces[i].vertex3.textureVertex.v;

                GL.glTexCoord2f( u_m, v_m );
                GL.glVertex3f( x_m, y_m, z_m );

                GL.glEnd();

                chris   -= 0.001f;
                defjam  += 0.001f;
                cori    -= 0.001f;

            } //endfor
        } //endmethod


        public void setupTestWorld()
        {
            mesh1.tripleFaces = new TripleFace[ LevelData.triangles_sector1.Length / 3 ];

            int currentFace = 0;

            //toDo: assign all vertices!

            //assign all faces
            for ( int i=0; i < mesh1.tripleFaces.Length; ++i )
            {
                mesh1.tripleFaces[ i ] = new TripleFace
                (
                    0,
                    new Vertex
                    (
                        LevelData.triangles_sector1[ currentFace ][ 0 ],
                        LevelData.triangles_sector1[ currentFace ][ 1 ],
                        LevelData.triangles_sector1[ currentFace ][ 2 ],
                        new TextureVertex
                        (
                            LevelData.triangles_sector1[ currentFace ][ 3 ],
                            LevelData.triangles_sector1[ currentFace ][ 4 ]
                        )
                    ),
                    new Vertex
                    (
                        LevelData.triangles_sector1[ currentFace + 1 ][ 0 ],
                        LevelData.triangles_sector1[ currentFace + 1 ][ 1 ],
                        LevelData.triangles_sector1[ currentFace + 1 ][ 2 ],
                        new TextureVertex
                        (
                            LevelData.triangles_sector1[ currentFace + 1 ][ 3 ],
                            LevelData.triangles_sector1[ currentFace + 1 ][ 4 ]
                        )
                    ),
                    new Vertex
                    (
                        LevelData.triangles_sector1[ currentFace + 2 ][ 0 ],
                        LevelData.triangles_sector1[ currentFace + 2 ][ 1 ],
                        LevelData.triangles_sector1[ currentFace + 2 ][ 2 ],
                        new TextureVertex
                        (
                            LevelData.triangles_sector1[ currentFace + 2 ][ 3 ],
                            LevelData.triangles_sector1[ currentFace + 2 ][ 4 ]
                        )
                    )
                );

                currentFace += 3;

            } //endfor
        } //endmethod

                case Keys.L:
                {
                    if ( OpenGLControlView.openGLControlView.light )
                    {
                        GL.glDisable( GL.GL_LIGHTING );
                        OpenGLControlView.openGLControlView.light = false;
                    }
                    else
                    {
                        GL.glEnable( GL.GL_LIGHTING );
                        OpenGLControlView.openGLControlView.light = true;
                    } //endif
                    break;
                } //endcase

                case Keys.F:
                {
                    OpenGLControlView.openGLControlView.currentTexture = ( OpenGLControlView.openGLControlView.currentTexture + 1) % 3;
                    break;
                } //endcase

                case Keys.B:
                {
                    OpenGLControlView.openGLControlView.blend = !OpenGLControlView.openGLControlView.blend;
                    if (OpenGLControlView.openGLControlView.blend)
                    {
                        GL.glEnable(GL.GL_BLEND);            // Turn Blending On
                        GL.glDisable(GL.GL_DEPTH_TEST);        // Turn Depth Testing Off
                    }
                    else
                    {
                        GL.glDisable(GL.GL_BLEND);            // Turn Blending Off
                        GL.glEnable(GL.GL_DEPTH_TEST);        // Turn Depth Testing On
                    }
                    break;
                } //endcase

            //set light
            GL.glLightfv(       GL.GL_LIGHT7, GL.GL_AMBIENT,  new float[] {0.5f, 0.5f, 0.5f, 1.0f} );    // Setup The Ambient Light
            GL.glLightfv(       GL.GL_LIGHT7, GL.GL_DIFFUSE,  new float[] {1.0f, 1.0f, 1.0f, 1.0f} );    // Setup The Diffuse Light
            GL.glLightfv(       GL.GL_LIGHT7, GL.GL_POSITION, new float[] {0.0f, 0.0f, 2.0f, 1.0f} );    // Position The Light
            GL.glEnable(        GL.GL_LIGHT7 );                                                            // Enable Light One



        public static float[][] triangles_sector1 = new float[][]
        {
            // Floor 1
            new float[] {   -3.0f, 0.0f, -3.0f,    0.0f,    6.0f,    },
            new float[] {   -3.0f, 0.0f, 3.0f,     0.0f,    0.0f,    },
            new float[] {    3.0f, 0.0f, 3.0f,     6.0f,    0.0f,    },

            new float[] {   -3.0f, 0.0f, -3.0f,    0.0f,    6.0f,    },
            new float[] {    3.0f, 0.0f, -3.0f,    6.0f,    6.0f,    },
            new float[] {    3.0f, 0.0f, 3.0f,     6.0f,    0.0f,    },

            // Ceiling 1
            new float[] {   -3.0f, 1.0f, -3.0f, 0.0f, 6.0f,  },
            new float[] {   -3.0f, 1.0f,  3.0f, 0.0f, 0.0f,  },
            new float[] {    3.0f, 1.0f,  3.0f, 6.0f, 0.0f,  },

            new float[] {   -3.0f, 1.0f, -3.0f, 0.0f, 6.0f,  },
            new float[] {    3.0f, 1.0f, -3.0f, 6.0f, 6.0f,  },
            new float[] {    3.0f, 1.0f,  3.0f, 6.0f, 0.0f,  },

            // A1
            new float[] {   -2.0f,  1.0f,  -2.0f, 0.0f, 1.0f,    },
            new float[] {   -2.0f,  0.0f,  -2.0f, 0.0f, 0.0f,    },
            new float[] {   -0.5f,  0.0f,  -2.0f, 1.5f, 0.0f,    },

            new float[] {   -2.0f,  1.0f,  -2.0f, 0.0f, 1.0f,    },
            new float[] {   -0.5f,  1.0f,  -2.0f, 1.5f, 1.0f,    },
            new float[] {   -0.5f,  0.0f,  -2.0f, 1.5f, 0.0f,    },

            // A2
            new float[] {    2.0f,  1.0f,  -2.0f, 2.0f, 1.0f,    },
            new float[] {    2.0f,  0.0f,  -2.0f, 2.0f, 0.0f,    },
            new float[] {    0.5f,  0.0f,  -2.0f, 0.5f, 0.0f,    },

            new float[] {    2.0f,  1.0f,  -2.0f, 2.0f, 1.0f,    },
            new float[] {    0.5f,  1.0f,  -2.0f, 0.5f, 1.0f,    },
            new float[] {    0.5f,  0.0f,  -2.0f, 0.5f, 0.0f,    },

            // B1
            new float[] {   -2.0f,  1.0f,  2.0f, 2.0f, 1.0f, },
            new float[] {   -2.0f,  0.0f,  2.0f, 2.0f, 0.0f, },
            new float[] {   -0.5f,  0.0f,  2.0f, 0.5f, 0.0f, },

            new float[] {   -2.0f,  1.0f,  2.0f, 2.0f, 1.0f, },
            new float[] {   -0.5f,  1.0f,  2.0f, 0.5f, 1.0f, },
            new float[] {   -0.5f,  0.0f,  2.0f, 0.5f, 0.0f, },

            // B2
            new float[] {    2.0f,  1.0f,  2.0f, 2.0f, 1.0f, },
            new float[] {    2.0f,  0.0f,  2.0f, 2.0f, 0.0f, },
            new float[] {    0.5f,  0.0f,  2.0f, 0.5f, 0.0f, },

            new float[] {    2.0f,  1.0f,  2.0f, 2.0f, 1.0f, },
            new float[] {    0.5f,  1.0f,  2.0f, 0.5f, 1.0f, },
            new float[] {    0.5f,  0.0f,  2.0f, 0.5f, 0.0f, },

            // C1
            new float[] {   -2.0f,  1.0f,  -2.0f, 0.0f, 1.0f, },
            new float[] {   -2.0f,  0.0f,  -2.0f, 0.0f, 0.0f, },
            new float[] {   -2.0f,  0.0f,  -0.5f, 1.5f, 0.0f, },

            new float[] {   -2.0f,  1.0f,  -2.0f, 0.0f, 1.0f, },
            new float[] {   -2.0f,  1.0f,  -0.5f, 1.5f, 1.0f, },
            new float[] {   -2.0f,  0.0f,  -0.5f, 1.5f, 0.0f, },

            // C2
            new float[] {   -2.0f,  1.0f,   2.0f, 2.0f, 1.0f, },
            new float[] {   -2.0f,  0.0f,   2.0f, 2.0f, 0.0f, },
            new float[] {   -2.0f,  0.0f,   0.5f, 0.5f, 0.0f, },

            new float[] {   -2.0f,  1.0f,   2.0f, 2.0f, 1.0f, },
            new float[] {   -2.0f,  1.0f,   0.5f, 0.5f, 1.0f, },
            new float[] {   -2.0f,  0.0f,   0.5f, 0.5f, 0.0f, },

            // D1
            new float[] {   2.0f, 1.0f, -2.0f, 0.0f, 1.0f,   },
            new float[] {   2.0f, 0.0f, -2.0f, 0.0f, 0.0f,   },
            new float[] {   2.0f, 0.0f, -0.5f, 1.5f, 0.0f,   },

            new float[] {   2.0f, 1.0f, -2.0f, 0.0f, 1.0f,   },
            new float[] {   2.0f, 1.0f, -0.5f, 1.5f, 1.0f,   },
            new float[] {   2.0f, 0.0f, -0.5f, 1.5f, 0.0f,   },

            // D2
            new float[] {   2.0f, 1.0f, 2.0f, 2.0f, 1.0f,    },
            new float[] {   2.0f, 0.0f, 2.0f, 2.0f, 0.0f,    },
            new float[] {   2.0f, 0.0f, 0.5f, 0.5f, 0.0f,    },

            new float[] {   2.0f, 1.0f, 2.0f, 2.0f, 1.0f,    },
            new float[] {   2.0f, 1.0f, 0.5f, 0.5f, 1.0f,    },
            new float[] {   2.0f, 0.0f, 0.5f, 0.5f, 0.0f,    },

            // Upper hallway - L
            new float[] {   -0.5f, 1.0f, -3.0f, 0.0f, 1.0f,  },
            new float[] {   -0.5f, 0.0f, -3.0f, 0.0f, 0.0f,  },
            new float[] {   -0.5f, 0.0f, -2.0f, 1.0f, 0.0f,  },

            new float[] {   -0.5f, 1.0f, -3.0f, 0.0f, 1.0f,  },
            new float[] {   -0.5f, 1.0f, -2.0f, 1.0f, 1.0f,  },
            new float[] {   -0.5f, 0.0f, -2.0f, 1.0f, 0.0f,  },

            // Upper hallway - R
            new float[] {   0.5f, 1.0f, -3.0f, 0.0f, 1.0f,   },
            new float[] {   0.5f, 0.0f, -3.0f, 0.0f, 0.0f,   },
            new float[] {   0.5f, 0.0f, -2.0f, 1.0f, 0.0f,   },

            new float[] {   0.5f, 1.0f, -3.0f, 0.0f, 1.0f,   },
            new float[] {   0.5f, 1.0f, -2.0f, 1.0f, 1.0f,   },
            new float[] {   0.5f, 0.0f, -2.0f, 1.0f, 0.0f,   },

            // Lower hallway - L
            new float[] {   -0.5f, 1.0f, 3.0f, 0.0f, 1.0f,   },
            new float[] {   -0.5f, 0.0f, 3.0f, 0.0f, 0.0f,   },
            new float[] {   -0.5f, 0.0f, 2.0f, 1.0f, 0.0f,   },

            new float[] {   -0.5f, 1.0f, 3.0f, 0.0f, 1.0f,   },
            new float[] {   -0.5f, 1.0f, 2.0f, 1.0f, 1.0f,   },
            new float[] {   -0.5f, 0.0f, 2.0f, 1.0f, 0.0f,   },

            // Lower hallway - R
            new float[] {   0.5f, 1.0f, 3.0f, 0.0f, 1.0f,    },
            new float[] {   0.5f, 0.0f, 3.0f, 0.0f, 0.0f,    },
            new float[] {   0.5f, 0.0f, 2.0f, 1.0f, 0.0f,    },

            new float[] {   0.5f, 1.0f, 3.0f, 0.0f, 1.0f,    },
            new float[] {   0.5f, 1.0f, 2.0f, 1.0f, 1.0f,    },
            new float[] {   0.5f, 0.0f, 2.0f, 1.0f, 0.0f,    },

            // Left hallway - Lw
            new float[] {   -3.0f,  1.0f,  0.5f, 1.0f, 1.0f, },
            new float[] {   -3.0f,  0.0f,  0.5f, 1.0f, 0.0f, },
            new float[] {   -2.0f,  0.0f,  0.5f, 0.0f, 0.0f, },

            new float[] {   -3.0f,  1.0f,  0.5f, 1.0f, 1.0f, },
            new float[] {   -2.0f,  1.0f,  0.5f, 0.0f, 1.0f, },
            new float[] {   -2.0f,  0.0f,  0.5f, 0.0f, 0.0f, },

            // Left hallway - Hi
            new float[] {   -3.0f, 1.0f, -0.5f, 1.0f, 1.0f,  },
            new float[] {   -3.0f, 0.0f, -0.5f, 1.0f, 0.0f,  },
            new float[] {   -2.0f, 0.0f, -0.5f, 0.0f, 0.0f,  },

            new float[] {   -3.0f, 1.0f, -0.5f, 1.0f, 1.0f,  },
            new float[] {   -2.0f, 1.0f, -0.5f, 0.0f, 1.0f,  },
            new float[] {   -2.0f, 0.0f, -0.5f, 0.0f, 0.0f,  },

            // Right hallway - Lw
            new float[] {   3.0f, 1.0f, 0.5f, 1.0f, 1.0f,    },
            new float[] {   3.0f, 0.0f, 0.5f, 1.0f, 0.0f,    },
            new float[] {   2.0f, 0.0f, 0.5f, 0.0f, 0.0f,    },

            new float[] {   3.0f, 1.0f, 0.5f, 1.0f, 1.0f,    },
            new float[] {   2.0f, 1.0f, 0.5f, 0.0f, 1.0f,    },
            new float[] {   2.0f, 0.0f, 0.5f, 0.0f, 0.0f,    },

            // Right hallway - Hi
            new float[] {   3.0f, 1.0f, -0.5f, 1.0f, 1.0f,   },
            new float[] {   3.0f, 0.0f, -0.5f, 1.0f, 0.0f,   },
            new float[] {   2.0f, 0.0f, -0.5f, 0.0f, 0.0f,   },

            new float[] {   3.0f, 1.0f, -0.5f, 1.0f, 1.0f,   },
            new float[] {   2.0f, 1.0f, -0.5f, 0.0f, 1.0f,   },
            new float[] {   2.0f, 0.0f, -0.5f, 0.0f, 0.0f,   },

        }; //endarray

*/

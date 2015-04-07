/*  $Id: TickerSystem.cs,v 1.1 2006/11/17 06:47:40 jenetic.bytemare Exp $
 *  =================================================================================
 *  The 3dsmax-loader.
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Classes
{
    public class TickerSystem : Timer
    {
        private const   int             DELAY           = 25;
        public  static  TickerSystem    tickerSystem    = null;

        public static void init()
        {
            tickerSystem = new TickerSystem();
            tickerSystem.Interval = DELAY;
            tickerSystem.Tick += new EventHandler( run );
            tickerSystem.Start();
        } //endmethod

        protected static void run( Object objSender, EventArgs e )
        {
            onRun();                                        //calculating
            LevelEditorForm.levelEditorForm.Refresh();      //refresh drawing

        } //endmethod

        private static void onRun()
        {
            //assign new position if position will not be changed
            //Console.WriteLine( "ok" );

        } //endmethod
    } //endclass



} //endnamespace

/*
 *  $Log: TickerSystem.cs,v $
 *  Revision 1.1  2006/11/17 06:47:40  jenetic.bytemare
 *  safe
 *
 *  Revision 1.2  2006/10/16 11:35:13  Mr. jenetic.bytemare
 *  editor makings
 *
 *  Revision 1.1  2006/10/31 03:16:10  Mr. jenetic.bytemare
 *  level-editor in progress
 *
 */

    
using System;
using Utilities;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Windows.Input;
using WindowsInput.Native;


namespace TotemSmash_{

    public partial class Form1 : Form{

        // #stolen
        WindowsInput.InputSimulator SimKeypress = new WindowsInput.InputSimulator();
        globalKeyboardHook gkh = new globalKeyboardHook();
        List<KeyValuePair<string, Macro>> MacroList = new List<KeyValuePair<string, Macro>>(); 
        Stopwatch stopwatch = new Stopwatch();
        List<Keys> AllKeys = new List<Keys> {Keys.LControlKey, Keys.LShiftKey, Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G, Keys.H, Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y, Keys.Z, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9 };
        //TODO: Really lazy way to determine our action, needs updated later
        public int status = -1;       
        SelectKeybind selectkeybind = new SelectKeybind();

        public Form1(){ 
            
            InitializeComponent();
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);           
            gkh.HookedKeys.AddRange(AllKeys);
            
        }

        void gkh_KeyUp(object sender, KeyEventArgs e){
           
        }

        void gkh_KeyDown(object sender, KeyEventArgs e){

            try {                

                txtOut.AppendText(e.KeyCode.ToString());

                //If status 0 creating new macro get input and save as keybind for macro
                //If status 1 recording new macro collect keyboard inputs and record time between inputs
                //If status 2 not recording check out list of saved keybinds and perform any actions necessary 
                switch (status) {

                    case 0:
                        //add new macro to our macro list
                        selectkeybind.Hide();
                        Macro macro = new Macro();
                        MacroList.Add(new KeyValuePair<string, Macro>(e.KeyCode.ToString(), macro));
                        status = 2;
                        break;

                    case 1:

                        try {                       
                            //record macro actions
                            foreach (KeyValuePair<string, Macro> _macro in MacroList) {

                                if (_macro.Value.ToString() == e.KeyCode.ToString()) {

                                    _macro.Value.KeySimulation.Clear();
                                    _macro.Value.KeySimulation.Add(new KeyValuePair<long, string>(stopwatch.ElapsedMilliseconds, e.KeyCode.ToString()));
                                }
                            }
                        }
                        catch (Exception exc) {

                            MessageBox.Show(exc.ToString());
                        }

                        UpdateMacroList();
                        e.Handled = true;
                        status = 2;
                        break;

                    case 2:
                        //scan key presses for bound key and playback macro if bound key is pressed
                        try {

                            //record macro actions
                            foreach (KeyValuePair<string, Macro> _macro in MacroList) {

                                if (_macro.Value.ToString() == e.KeyCode.ToString()) {

                                    _macro.Value.KeySimulation.Clear();
                                    _macro.Value.KeySimulation.Add(new KeyValuePair<long, string>(stopwatch.ElapsedMilliseconds, e.KeyCode.ToString()));
                                }
                            }
                        }
                        catch (Exception exc) {

                            MessageBox.Show(exc.ToString());
                        }

                        e.Handled = true;
                        break;
                }
               
            }
            catch (Exception exc) {

                MessageBox.Show("There was an error capturing mouse / keyboard data, its possible every keypress will produce this error. Close the program to stop this." );
            }
        } 

        private void btnRecord_Click(object sender, EventArgs e){

            stopwatch.Start();
            status = 1;
        }

        private void btnStopRecord_Click(object sender, EventArgs e){

            stopwatch.Stop();
            stopwatch.Reset();
            status = 2;
        }

        private void NewMacro_Click(object sender, EventArgs e) {

            status = 1;           
            selectkeybind.Show();
        }

        public void UpdateMacroList() {

            macroListBox.Items.Clear();

            foreach (KeyValuePair<string, Macro> _macro in MacroList) {
                
                macroListBox.Items.Add(_macro.Key);
            }
        }

        private void macroListBox_SelectedIndexChanged(object sender, EventArgs e) {

            //TODO: load macro actions
        }
    }
}

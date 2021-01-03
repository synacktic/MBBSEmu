using MBBSEmu.GUI.Logging;
using MBBSEmu.Resources;
using System.Collections.Generic;
using System.Threading;
using MBBSEmu.Server;
using Terminal.Gui;

namespace MBBSEmu.GUI
{
    public class MainInterface : IStoppable
    {
        /// <summary>
        ///     Main UI Window
        /// </summary>
        private Window _mainWindow;

        /// <summary>
        ///     Menu Bar for the Main UI Window
        /// </summary>
        private MenuBar _mainMenuBar;

        private FrameView _availableViewsWindow;

        private FrameView _viewDetailWindow;

        private readonly List<string> _views = new() { "MBBSEmu Logs" };

        public readonly UILoggingTarget UILogger;

        public Thread InterfaceThread;

        public MainInterface()
        {
            UILogger = new UILoggingTarget("UILoggingTarget");
            Application.Init();

            _mainWindow = new Window(new Rect(0, 1, Application.Top.Frame.Width, Application.Top.Frame.Height - 1), $"MBBSEmu {new ResourceManager().GetString("MBBSEmu.Assets.version.txt")}");

            _availableViewsWindow = new FrameView("Views")
            {
                X = 0,
                Y = 1, // for menu
                Width = 25,
                Height = Dim.Fill(1),
                CanFocus = false,
                Title = "Views"
            };

            var _viewsList = new ListView(_views)
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(0),
                Height = Dim.Fill(0),
                AllowsMarking = false,
                CanFocus = true,
            };
            _viewsList.OpenSelectedItem += (a) =>
            {
                _viewDetailWindow.SetFocus();
            };
            _viewsList.SelectedItemChanged += ViewList_SelectedViewChanged;
            _availableViewsWindow.Add(_viewsList);

            _mainWindow.Add(_availableViewsWindow);

            //Draw Menu Items
            // Creates a menu bar, the item "New" has a help menu.
            var menuItems = new List<MenuBarItem>();

            menuItems.Add(
                new MenuBarItem("_File", new[]
                {
                    new MenuItem("_Exit", "", () => { Application.Top.Running = false; })
                }));

            _mainMenuBar = new MenuBar(menuItems.ToArray());
            _mainWindow.Add(_mainMenuBar);
            Application.Top.Add(_mainWindow);
        }

        public bool Start()
        {
            InterfaceThread = new Thread(Application.Run);
            InterfaceThread.Start();
            return true;
        }

        private void ViewList_SelectedViewChanged(ListViewItemEventArgs e)
        {
            var selectedView = _views[e.Item];

            switch (e.Item)
            {
                //MBBSEmu Log
                case 0:
                    {
                        _viewDetailWindow = new FrameView("MBBSEmu Log")
                        {
                            X = 25,
                            Y = 1, // for menu
                            Width = Dim.Fill(),
                            Height = Dim.Fill(1),
                            CanFocus = true
                        };

                        var _logView = new ScrollView()
                        {
                            ContentSize = new Size(200, 200),
                            ShowVerticalScrollIndicator = true,
                            ShowHorizontalScrollIndicator = true,
                            X = 0,
                            Y = 0,
                            Height = Dim.Fill(),
                            Width = Dim.Fill()
                        };

                        for (var i = 0; i < UILogger.Log.Count; i++)
                        {
                            var l = UILogger.Log[i];
                            _logView.Add(new TextField(0, i, 255, l));
                        }

                        _logView.ScrollDown(UILogger.Log.Count);
                        _viewDetailWindow.Add(_logView);
                        _mainWindow.Add(_viewDetailWindow);
                        break;
                    }
            }

        }

        public void Stop()
        {
            Application.RequestStop();
        }
    }
}

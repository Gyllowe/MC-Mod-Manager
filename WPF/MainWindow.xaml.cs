using MC_Mod_Manager.Scripts;
using MC_Mod_Manager.Scripts.Menus;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MC_Mod_Manager_Common;

namespace MC_Mod_Manager;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }



    // Mod managing menu button
    private void MenuSelect_AllMods(object sender, RoutedEventArgs e) { }



    private void ModListCompactView_Checked(object sender, RoutedEventArgs e) { _RefreshModList(); }

    private void ModListCollapseExpanders_Click(object sender, RoutedEventArgs e) {
        foreach(Expander expander in ModList.Children) {
            expander.IsExpanded = false;
        }
    }


    // Add mod panel
    private void AddModExpanderClosed(object sender, RoutedEventArgs e) {
        AddModNoNameError.Visibility = Visibility.Hidden;
    }
    private void AddMod_Click(object sender, RoutedEventArgs e) {
        string NewModName = ModNameTextBox.Text;
        string NewModAuthor = CreatorTextBox.Text;

        if(NewModName == "") {
            AddModNoNameError.Visibility = Visibility.Visible;
            return;
        }
        AddModNoNameError.Visibility = Visibility.Hidden;

        ModManager.NewMod(NewModName);
        Mod newMod = ModManager.Mods[ModManager.Mods.Count - 1];
        ModMenu.ModlistExpanders.Add(newMod, null);
        //_SetModList(ModMenu.GetModsTextBlock());

        _RefreshModList();
    }


    //
    private void ManageModButton_Click(object sender, RoutedEventArgs e) {
        ManageModPanel.Visibility =
            ManageModPanel.Visibility == Visibility.Collapsed ?
            Visibility.Visible :
            Visibility.Collapsed;
    }

    // TODO: Implement
    private void ManageModRenameButton_Click(object sender, RoutedEventArgs e) { }


    // TODO: Implement
    private void ManageModChangeCreatorButton_Click(object sender, RoutedEventArgs e) { }


    //
    private void ModInstancesPanelButton_Click(object sender, RoutedEventArgs e) {
        if(ModInstancesPanel.Visibility == Visibility.Collapsed) {
            ModInstancesPanel.Visibility = Visibility.Visible;
            AddModExpander.IsExpanded = false;
            //HideOtherWindows_ModMenu("ModInstancesPanel");
        } else {
            ModInstancesPanel.Visibility = Visibility.Collapsed;
        }
    }

    // TODO: Implement
    private void SelectedModsPanelButton_Click(object sender, RoutedEventArgs e) { }
    // TODO: Implement
    private void SelectedModsSort_Click(object sender, RoutedEventArgs e) { }




    // Not using now, but should probably be implemented later
    private void HideOtherWindows_ModMenu(string keepWindow) { }

    //
    private void _RefreshModList() {
        // Save which expanders were open
        Dictionary<Mod, bool> expandedItems = new();
        var expanders = ModMenu.ModlistExpanders;
        foreach(Mod mod in expanders.Keys) {
            if(expanders[mod] == null) {
                expandedItems.Add(mod, false);
                continue;
            }
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            expandedItems.Add(mod, expanders[mod].IsExpanded);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
        ModMenu.ModlistExpanders.Clear();

        // Clear the ModList
        ModList.Children.Clear();

        // Make new expander and add reference to
        // ModMenu.ModlistExpanders
        foreach(Mod mod in ModMenu.GetMods()) {
            Expander expander = _GenerateModListExpander(mod, ModListCompactView.IsChecked);
            ModList.Children.Add(expander);

            expander.IsExpanded = expandedItems[mod];

            ModMenu.ModlistExpanders.Add(mod, expander);

            // The Name property of the expanders could be set to the mods name to access them more
            // easily, but it has some restrictions and can't just be any string. For example,
            // expander.Name = "1"; would result in an error. Documentation:
            // docs.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement.name
        }
    }
    // WIP
    private static Expander _GenerateModListExpander(Mod mod, bool? compact) {
        Expander expander = new();
        Label header = new();
        StackPanel panel = new();


        header.Content = mod.Name;


        Label label1 = new() {
            Content = mod.Name
        };

        Label label2 = new() {
            Content = "By: " + mod.Creator
        };

        panel.Children.Add(label1);
        panel.Children.Add(label2);


        _GenerateDependenciesExpander(ref panel, mod);


        if(compact == true) {
            expander.Header = mod.Name;
        } else {
            expander.Header = header;
        }

        expander.Content = panel;
        return expander;
    }

    //
    private static void _GenerateDependenciesExpander(ref StackPanel expanderContent, Mod mod) {
        if(mod.Depenencies.Count == 0) {
            Label label = new();
            label.Content = "Dependencies: none";

            expanderContent.Children.Add(label);
            return;
        }


        WrapPanel wrapPanel = new();
        wrapPanel.Orientation = Orientation.Horizontal;

        foreach(Mod depend in mod.Depenencies) {
            Label label = new();
            label.Content = depend.Name;

            wrapPanel.Children.Add(label);
        }

        Expander expander = new();
        expander.Header = "Dependencies";
        expander.Content = wrapPanel;

        expanderContent.Children.Add(expander);
    }





    // >>OBSOLETE<<
    // But keepng for the memories :)
    void _SetModList(string input) {
        ModMenuTextBlock.Text = input;
    }
}



/*
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="60"/>
        <ColumnDefinition Width="1*"/>
       </Grid.ColumnDefinitions>

    <Grid Grid.Column="0" Background="LightGray">
        <Grid.RowDefinitions>
            <RowDefinition Height="60"/>
            <RowDefinition Height="60"/>
            <RowDefinition Height="60"/>
            <RowDefinition Height="1*"/>
            <RowDefinition Height="60"/>
        </Grid.RowDefinitions>

        <Button
            x:Name="AllModsSidebarButton"
            Click="AllModsSidebarButton_Click"
            Background="LightGreen"
            Grid.Row="0"
            Content="All mods"
        ></Button>

        <Button
            x:Name="ClientModsSidebarButton"
            Grid.Row="1"
            Background="LightGray"
        >
            <TextBlock TextAlignment="Center">
                Client
                <LineBreak/>
                profiles
            </TextBlock>
        </Button>

        <Button
            x:Name="ServerModsSidebarButton"
            Grid.Row="2"
            Background="LightGray"
        >
            <TextBlock TextAlignment="Center">
                Server
                <LineBreak/>
                profiles
            </TextBlock>
        </Button>
    </Grid>

    <Canvas Grid.Column="1">
        
        
        
        <StackPanel Grid.Column="1">
            
            
        </StackPanel>
    </Canvas>
</Grid>
*/

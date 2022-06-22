using ReactiveUI;
using System.Drawing;
using System.Reactive;

namespace AvaloniaFontFamilyBinding.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public const string FONT_WHEN_TRUE = "Courier New";
    public const string FONT_WHEN_FALSE = "Times New Roman";

    public MainWindowViewModel()
    {
        FontFamilyA = new(FONT_WHEN_FALSE);
        FontFamilyB = new(FONT_WHEN_FALSE);

        SwitchFontFamilyACommand = ReactiveCommand.Create(OnSwitchFontFamilyA);
        SwitchFontFamilyBCommand = ReactiveCommand.Create(OnSwitchFontFamilyB);
    }

    private bool _fontFamilyASwitch = false;
    private FontFamily _fontFamilyA = null!;
    public FontFamily FontFamilyA
    {
        get => _fontFamilyA;
        set => this.RaiseAndSetIfChanged(ref _fontFamilyA, value);
    }

    private bool _fontFamilyBSwitch = false;
    private FontFamily _fontFamilyB = null!;
    public FontFamily FontFamilyB
    {
        get => _fontFamilyB;
        set => this.RaiseAndSetIfChanged(ref _fontFamilyB, value);
    }

    public ReactiveCommand<Unit, Unit> SwitchFontFamilyACommand { get; }
    private void OnSwitchFontFamilyA()
    {
        _fontFamilyASwitch = !_fontFamilyASwitch;
        FontFamilyA = new(_fontFamilyASwitch ? FONT_WHEN_TRUE : FONT_WHEN_FALSE);
    }

    public ReactiveCommand<Unit, Unit> SwitchFontFamilyBCommand { get; }
    private void OnSwitchFontFamilyB()
    {
        _fontFamilyBSwitch = !_fontFamilyBSwitch;
        FontFamilyB = new(_fontFamilyBSwitch ? FONT_WHEN_TRUE : FONT_WHEN_FALSE);
    }
}

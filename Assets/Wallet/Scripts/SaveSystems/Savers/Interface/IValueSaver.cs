namespace Wallet
{
public interface IValueSaver
{
    public int Load(ValueKey key);
    public void Save(ValueKey key, int value);

}
}
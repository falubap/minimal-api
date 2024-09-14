namespace MinimalApi.Dominio.ModelViews;

public struct Home
{
    public readonly string Mensagem { get => "Bem vindo à API Veículos"; }
    public readonly string Doc { get => "/swagger"; }
}
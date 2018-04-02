﻿namespace GA.WebAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Usuario RetornarUsuario(int id)
        {
            return new Usuario { Id = id, Nome = $"Usuario - {id}" };
        }
    }
}
﻿using System.ComponentModel.DataAnnotations;

namespace GestionDeTareas.Model
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
    }
}

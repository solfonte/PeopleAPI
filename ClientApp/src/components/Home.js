import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>¡Bienvenido!</h1>
        <p>En esta API podes agregar, eliminar y editar personas.</p>
        <p>Desarrolladora: Sol Fontenla</p>
      </div>
    );
  }
}

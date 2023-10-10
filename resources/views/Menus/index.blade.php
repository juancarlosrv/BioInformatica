@extends('app')

 

@section('content')

<div class="container">

    <h1>Lista de Menús</h1>

    <a href="{{ route('menus.create') }}" class="btn btn-primary">Crear Menú</a>

    <table class="table mt-3">

        <thead>

            <tr>

                <th>ID</th>

                <th>Título</th>

                <th>Categoría IMC</th>

                <th>Tipo de Comida</th>

                <th>Acciones</th>

            </tr>

        </thead>

        <tbody>

            @foreach($menus as $menu)

            <tr>

                <td>{{ $menu->id }}</td>

                <td>{{ $menu->titulo }}</td>

                <td>{{ $menu->categoria_imc }}</td>

                <td>{{ $menu->tipo_comida }}</td>

                <td>

                    <a href="{{ route('menus.show', $menu->id) }}" class="btn btn-info">Ver</a>

                    <a href="{{ route('menus.edit', $menu->id) }}" class="btn btn-primary">Editar</a>

                    <form action="{{ route('menus.destroy', $menu->id) }}" method="POST" style="display: inline;">

                        @csrf

                        @method('DELETE')

                        <button type="submit" class="btn btn-danger">Eliminar</button>

                    </form>

                </td>

            </tr>

            @endforeach

        </tbody>

    </table>

</div>

@endsection

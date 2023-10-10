@extends('app')

 

@section('content')
<div class="container">
<h1>Detalles del Menú</h1>
<div class="card">
<div class="card-body">
<h5 class="card-title">{{ $menu->titulo }}</h5>
<p class="card-text"><strong>Categoría IMC:</strong> {{ $menu->categoria_imc }}</p>
<p class="card-text"><strong>Tipo de Comida:</strong> {{ $menu->tipo_comida }}</p>
<!-- Agrega más detalles según tus necesidades -->
<a href="{{ route('menus.index') }}" class="btn btn-primary">Volver al Listado</a>
</div>
</div>
</div>
@endsection
@extends('app')

 

@section('content')
<div class="container">
<h1>Crear Menú</h1>
<form action="{{ route('menus.store') }}" method="POST">
        @csrf
<div class="form-group">
<label for="titulo">Título</label>
<input type="text" class="form-control" id="titulo" name="titulo" required>
</div>
<div class="form-group">
<label for="categoria_imc">Categoría IMC</label>
<input type="text" class="form-control" id="categoria_imc" name="categoria_imc" required>
</div>
<div class="form-group">
<label for="tipo_comida">Tipo de Comida</label>
<input type="text" class="form-control" id="tipo_comida" name="tipo_comida" required>
</div>
<!-- Agrega más campos del formulario según tus necesidades -->
<button type="submit" class="btn btn-primary">Crear</button>
</form>
</div>
@endsection
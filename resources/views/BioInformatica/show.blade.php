@extends('app');



@section('content')


</div>

    <h1 style="text-align: center;">
        FORMULARIO DE REGISTRO
    </h1>


<div class="row">

            <div class="col-1">

           

            </div>

        <div class="col-8">

        <form action="{{ route('personas-update',['id' => $persona->id]) }}" method="post">
        @method('PUT')
        @csrf


        



        @if (session('success'))
            
            <h6 class="alert alert-success">{{session('success') }} </h6>

        @endif

        @error('ci')
            
        <h6 class="alert alert-danger">{{ $message }} </h6>

        @enderror

                 <div class="form-group">

                  <label for="">CI</label>

                  <input type="text"

                    class="form-control" name="ci" id="ci" aria-describedby="helpId" value="{{ $persona->ci }}">

                 

                </div>
                <div class="form-group">

                  <label for="">Nombre</label>

                  <input type="text"

                    class="form-control" name="nombre" id="nombre" aria-describedby="helpId" value="{{ $persona->nombres }}">

                 

                </div>



                

 

                <div class="row">

                    <div class="col-6">

                        <div class="form-group">

                        <label for="">Apellido Paterno</label>

                        <input type="text"

                            class="form-control" name="apellidoPat" id="apellidoPat" aria-describedby="helpId" value="{{ $persona->apellidoPat }}">

                       

                        </div>

                    </div>

                    <div class="col-6">

                    <div class="form-group">

                        <label for="">Apellido Materno</label>

                        <input type="text"

                            class="form-control" name="apellidoMat" id="apellidoMat" aria-describedby="helpId" value="{{ $persona->apellidoMat }}">

                       

                        </div>

                    </div>

                </div>

 

                <div class="row">

                    <div class="col-4">

                        <div class="form-group">

                        <label for="fechaNac">Fecha de Nacimiento:</label>
                        <input type="date" class="form-control" id="fechaNac" name="fechaNac" value="{{ $persona->fechaNac }}"><br><br>

                         

                        </div>

                    </div>

                    <div class="col-4">

                    <div class="form-group">

                    <label for="altura">Altura (en cm):</label>
                    <input type="text"

                            class="form-control" name="altura" id="altura" aria-describedby="helpId" value="{{ $persona->altura }}">

                       

                        </div>

                       

                        </div>

                    


                    <div class="col-4">

                    <div class="form-group">

                    <label for="peso">Peso (en kg):</label>
                    <input type="number" class="form-control" id="peso" name="peso" value="{{ $persona->peso }}"><br><br>

                       

                        </div>

                    </div>

                </div>

 

        

                <button type="submit" class="btn btn-primary">Actualizar Usuario</button>

 

            </form>    

        </div>

        <div class="col-3">

        </div>



    </div>

@endsection


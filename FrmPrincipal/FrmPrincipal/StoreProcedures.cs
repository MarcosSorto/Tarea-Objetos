using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmPrincipal
{
    class StoreProcedures
    {

        // estos son los StoreProcedure Utilizados en la Tarea.

/// <summary>
/// Procedimiento para agregar un nuevo departamento.
/// </summary>
/// 

/*
 * 
 * CREATE PROCEDURE sp_RegistrarDepartamento(
    @Nombre NVarchar(50)=NULL,
    @Descripcion NVarchar(50)=NULL,
    @FechaM DATETIME = NULL
   )
    AS
    BEGIN

INSERT INTO HumanResources.Department(Name, GroupName, ModifiedDate) VALUES(@Nombre, @Descripcion, @FechaM)
END

/// <summary>
/// Procedimiento para Editar un  departamento.
/// </summary>

CREATE PROCEDURE sp_EditarDepartamento(
@Codigo SMALLINT = NULL,
@Nombre NVARCHAR(50)=NULL,
@Descripcion NVARCHAR(50)=NULL,
@FechaM DATETIME = NULL
)
AS
BEGIN


UPDATE HumanResources.Department SET Name = @Nombre, GroupName = @Descripcion, ModifiedDate= @FechaM WHERE DepartmentID = @Codigo;
END

/// <summary>
/// Procedimiento para Eliminar un  departamento.
/// </summary>

CREATE PROCEDURE sp_EliminarDepartamento(
    @Codigo SMALLINT = NULL
)
AS
BEGIN


DELETE FROM HumanResources.Department WHERE DepartmentID=@Codigo;
END*/
}
}

export function dataAtualFormatada(dataConsulta) {
  var data = new Date(dataConsulta),
    dia = data.getDate().toString(),
    diaF = dia.length == 1 ? "0" + dia : dia,
    mes = (data.getMonth() + 1).toString(),
    mesF = mes.length == 1 ? "0" + mes : mes,
    anoF = data.getFullYear(),
    hora = data.getHours(),
    minutos = data.getMinutes();

  return `${diaF}/${mesF}/${anoF} ${hora}:${minutos}`;
}

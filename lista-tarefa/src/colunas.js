import { v4 as uuidv4 } from "uuid";
import {data} from './data-mock'

export const columnsFromBackend = {
    [uuidv4()]: {
      title: "A Fazer",
      items: data,
    },
    [uuidv4()]: {
      title: "Fazendo",
      items: [],
    },
    [uuidv4()]: {
      title: "Feito",
      items: [],
    },
  }
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Language } from './Language';
import type { Suggestion } from './Suggestion';

export type Translation = {
    id?: string;
    key?: string | null;
    isOriginalLanguage?: boolean;
    language?: Language;
    content?: string | null;
    suggestions?: Array<Suggestion> | null;
}
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Translation } from './Translation';

export type Component = {
    readonly id?: string;
    description?: string | null;
    name?: string | null;
    isLock?: boolean;
    translations?: Array<Translation> | null;
}
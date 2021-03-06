/*                 
 *     EntityFrameworkCore.FirebirdSqlSQL  - Congratulations EFCore Team
 *              https://www.FirebirdSqlsql.org/en/net-provider/ 
 *     Permission to use, copy, modify, and distribute this software and its
 *     documentation for any purpose, without fee, and without a written
 *     agreement is hereby granted, provided that the above copyright notice
 *     and this paragraph and the following two paragraphs appear in all copies. 
 * 
 *     The contents of this file are subject to the Initial
 *     Developer's Public License Version 1.0 (the "License");
 *     you may not use this file except in compliance with the
 *     License. You may obtain a copy of the License at
 *     http://www.FirebirdSqlsql.org/index.php?op=doc&id=idpl
 *
 *     Software distributed under the License is distributed on
 *     an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either
 *     express or implied.  See the License for the specific
 *     language governing rights and limitations under the License.
 *
 *              Copyright (c) 2017 Rafael Almeida
 *         Made In Sergipe-Brasil - ralms@ralms.net 
 *                  All Rights Reserved.
 */ 

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Utilities;


namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    ///     FirebirdSQL specific extension methods for <see cref="PropertyBuilder" />.
    /// </summary>
    public static class FirebirdSqlPropertyBuilderExtensions
    {

        /// <summary>
        ///     Configures the key property to use the FirebirdSQL IDENTITY feature to generate values for new entities,
        ///     when targeting FirebirdSQL. This method sets the property to be <see cref="ValueGenerated.OnAdd" />.
        /// </summary>
        /// <param name="propertyBuilder"> The builder for the property being configured. </param>
        /// <returns> The same builder instance so that multiple calls can be chained. </returns>
        public static PropertyBuilder UseFirebirdSqlIdentityColumn(
            [NotNull] this PropertyBuilder propertyBuilder)
        {
            Check.NotNull(propertyBuilder, nameof(propertyBuilder));

            GetFirebirdSqlInternalBuilder(propertyBuilder).ValueGenerationStrategy(FirebirdSqlValueGenerationStrategy.IdentityColumn);

            return propertyBuilder;
        }

        /// <summary>
        ///     Configures the key property to use the FirebirdSQL IDENTITY feature to generate values for new entities,
        ///     when targeting FirebirdSQL. This method sets the property to be <see cref="ValueGenerated.OnAdd" />.
        /// </summary>
        /// <typeparam name="TProperty"> The type of the property being configured. </typeparam>
        /// <param name="propertyBuilder"> The builder for the property being configured. </param>
        /// <returns> The same builder instance so that multiple calls can be chained. </returns>
        public static PropertyBuilder<TProperty> UseFirebirdSqlIdentityColumn<TProperty>(
            [NotNull] this PropertyBuilder<TProperty> propertyBuilder)
            => (PropertyBuilder<TProperty>)UseFirebirdSqlIdentityColumn((PropertyBuilder)propertyBuilder);

        private static FirebirdSqlPropertyBuilderAnnotations GetFirebirdSqlInternalBuilder(PropertyBuilder propertyBuilder)
            => propertyBuilder.GetInfrastructure<InternalPropertyBuilder>().FirebirdSql(ConfigurationSource.Explicit);
    }
}
